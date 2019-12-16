#include "diagramscene.h"
#include "arrow.h"
#include <QTextCursor>
#include <QGraphicsSceneMouseEvent>
#include <QDebug>

QPen const DiagramScene::penForLines = QPen(QBrush(QColor(Qt::black)), 2, Qt::PenStyle::DashLine);

DiagramScene::DiagramScene(QMenu *itemMenu, QObject *parent)
    : QGraphicsScene(parent)
{
    myItemMenu = itemMenu;
    myMode = MoveItem;
    myItemType = DiagramElement::Step;
    line = nullptr;
    textItem = nullptr;
}

/**
 * Установить стиль шрифта
 */
void DiagramScene::setFont(const QFont &font)
{
    myFont = font;
    foreach (QGraphicsItem* p, selectedItems()) {
        if (p->type() == DiagramText::Type) {
            DiagramText* item = qgraphicsitem_cast<DiagramText*>(p);
            item->setFont(myFont);
        }
    }
}

/**
 * Удалить элемент
 */
void DiagramScene::deleteItems(QList<QGraphicsItem*> const& items) {
    QList<QGraphicsItem*> diagramItems;
    foreach (QGraphicsItem *item, items) {
        if (item->type() == Arrow::Type) {
            removeItem(item);
            Arrow *arrow = qgraphicsitem_cast<Arrow *>(item);
            arrow->startItem()->removeArrow(arrow);
            arrow->endItem()->removeArrow(arrow);
            delete item;
        } else diagramItems.append(item);
    }
    foreach (QGraphicsItem *item, diagramItems) {
        if (item->type() == DiagramElement::Type)
             qgraphicsitem_cast<DiagramElement *>(item)->removeArrows();
        removeItem(item);
        delete item;
    }
}

/**
 * Установить стиль
 */
void DiagramScene::setMode(Mode mode)
{
    myMode = mode;
}

/**
 * Установить тип элемента
 */
void DiagramScene::setItemType(DiagramElement::DiagramType type)
{
    myItemType = type;
}

void DiagramScene::editorLostFocus(DiagramText *item)
{
    QTextCursor cursor = item->textCursor();
    cursor.clearSelection();
    item->setTextCursor(cursor);

    if (item->toPlainText().isEmpty()) {
        removeItem(item);
        item->deleteLater();
    } else {
        if (item->contentIsUpdated()) {
            emit textChanged();
        }
    }

}

/**
 * Обработка события нажатия мыши
 */
void DiagramScene::mousePressEvent(QGraphicsSceneMouseEvent *mouseEvent)
{
    if (mouseEvent->button() != Qt::LeftButton)
        return;

    DiagramElement *item;
    switch (myMode) {
        case InsertItem:
            item = new DiagramElement(myItemType, myItemMenu);
            item->setBrush(Qt::white);
            addItem(item);
            item->setPos(mouseEvent->scenePos());
            emit itemInserted(item);
            hasItemSelected = itemAt(mouseEvent->scenePos(), QTransform()) != nullptr;
            break;

        case InsertLine:
            if (itemAt(mouseEvent->scenePos(), QTransform()) == nullptr) break;
            line = new QGraphicsLineItem(QLineF(mouseEvent->scenePos(),
                                        mouseEvent->scenePos()));
            line->setPen(QPen(Qt::black, 2));
            addItem(line);
            break;

        case InsertText:
            textItem = new DiagramText();
            textItem->setFont(myFont);
            textItem->setTextInteractionFlags(Qt::TextEditorInteraction);
            textItem->setZValue(1000.0);
            connect(textItem, SIGNAL(lostFocus(DiagramText*)),
                    this, SLOT(editorLostFocus(DiagramText*)));
            connect(textItem, SIGNAL(selectedChange(QGraphicsItem*)),
                    this, SIGNAL(itemSelected(QGraphicsItem*)));
            addItem(textItem);
            textItem->setDefaultTextColor(Qt::black);
            textItem->setPos(mouseEvent->scenePos());
            emit textInserted(textItem);
            break;

    default:
        hasItemSelected = itemAt(mouseEvent->scenePos(), QTransform()) != nullptr;
    }
    QGraphicsScene::mousePressEvent(mouseEvent);
}

/**
 * Обработка события перемещения мыши
 */
void DiagramScene::mouseMoveEvent(QGraphicsSceneMouseEvent *mouseEvent) {
    if (myMode == InsertLine && line != nullptr) {
        QLineF newLine(line->line().p1(), mouseEvent->scenePos());
        line->setLine(newLine);
    } else if (myMode == MoveItem) {
        if (hasItemSelected)
            mouseDraggingMoveEvent(mouseEvent);
        QGraphicsScene::mouseMoveEvent(mouseEvent);
    }
}

/**
 * Обработка события отпускания мыши
 */
void DiagramScene::mouseReleaseEvent(QGraphicsSceneMouseEvent *mouseEvent) {
    hasItemSelected = false;

    horizontalStickyMode = false;
    verticalStickyMode = false;
    foreach(QGraphicsItem* p, selectedItems())
        p->setFlag(QGraphicsItem::ItemIsMovable);

    clearOrthogonalLines();
    if (line != nullptr && myMode == InsertLine) {
        QList<QGraphicsItem *> startItems = items(line->line().p1());
        if (startItems.count() && startItems.first() == line)
            startItems.removeFirst();
        QList<QGraphicsItem *> endItems = items(line->line().p2());
        if (endItems.count() && endItems.first() == line)
            endItems.removeFirst();

        removeItem(line);
        delete line;

        if (startItems.count() > 0 && endItems.count() > 0 &&
            startItems.first()->type() == DiagramElement::Type &&
            endItems.first()->type() == DiagramElement::Type &&
            startItems.first() != endItems.first()) {
            DiagramElement *startItem = qgraphicsitem_cast<DiagramElement *>(startItems.first());
            DiagramElement *endItem = qgraphicsitem_cast<DiagramElement *>(endItems.first());
            Arrow *arrow = new Arrow(startItem, endItem);
            startItem->addArrow(arrow);
            endItem->addArrow(arrow);
            arrow->setZValue(-1000.0);
            addItem(arrow);
            arrow->updatePosition();
            emit arrowInserted();
        }
    }

    line = nullptr;
    QGraphicsScene::mouseReleaseEvent(mouseEvent);
}

/**
 * Обработка события прокрутки колесика мыши
 */
void DiagramScene::wheelEvent(QGraphicsSceneWheelEvent* wheelEvent) {
    if ((wheelEvent->modifiers() & Qt::KeyboardModifier::ControlModifier) != 0) {
        emit scaleChanging(wheelEvent->delta());
        wheelEvent->accept();
    } else {
        QGraphicsScene::wheelEvent(wheelEvent);
    }
}

/**
 * Обработка события перемещения при перетаскивания мыши
 */
void DiagramScene::mouseDraggingMoveEvent(QGraphicsSceneMouseEvent* event) {
    clearOrthogonalLines();
    if ((event->buttons() & Qt::LeftButton) != 0 && selectedItems().size() == 1) {
        QGraphicsItem* itemUnderCursor = selectedItems().first();
        QPointF curCenter = itemUnderCursor->scenePos();
        QPointF const& mousePos = event->scenePos();

        foreach(QGraphicsItem* p, items()) {
            if (p->type() != DiagramElement::Type || p == itemUnderCursor) continue;

            DiagramElement* item = qgraphicsitem_cast<DiagramElement*>(p);
            QPointF const& objPoint = item->scenePos();
            LineAttr lineAttr;

            tryEnteringStickyMode(itemUnderCursor, objPoint, mousePos);

            if ((lineAttr = getPointsRelationship(objPoint, curCenter)) != Other) {
                if ((lineAttr & Horizontal) != 0) {
                    QGraphicsLineItem* newHLine = new QGraphicsLineItem();
                    newHLine->setLine(QLineF(QPointF(0, objPoint.y()),
                                             QPointF(sceneRect().width(), objPoint.y())));
                    newHLine->setPen(penForLines);
                    orthogonalLines.append(newHLine);
                }
                if ((lineAttr & Vertical) != 0) {
                    QGraphicsLineItem* newVLine = new QGraphicsLineItem();
                    newVLine->setLine(QLineF(QPointF(objPoint.x(), 0),
                                             QPointF(objPoint.x(), sceneRect().height())));
                    newVLine->setPen(penForLines);
                    orthogonalLines.append(newVLine);
                }
            }
        }
        tryLeavingStickyMode(itemUnderCursor, mousePos);
    }
    foreach(QGraphicsLineItem* p, orthogonalLines) {
        addItem(p);
    }
}

void DiagramScene::clearOrthogonalLines() {
    foreach(QGraphicsLineItem* p, orthogonalLines) {
        removeItem(p);
        delete p;
    }
    orthogonalLines.clear();
}

bool DiagramScene::closeEnough(qreal x, qreal y, qreal delta) {
    return std::abs(x - y) < delta;
}

DiagramScene::LineAttr DiagramScene::getPointsRelationship(const QPointF& p1,
                                                           const QPointF& p2) {
    int ret = Other;
    ret |= closeEnough(p1.x(), p2.x(), Delta) ? Vertical : Other;
    ret |= closeEnough(p1.y(), p2.y(), Delta) ? Horizontal : Other;
    return static_cast<DiagramScene::LineAttr>(ret);
}

/**
 * Режим группировки элементов
 */
void DiagramScene::tryEnteringStickyMode(QGraphicsItem* item, const QPointF& target,
                                         const QPointF& mousePos) {
    QPointF const& itemPos = item->scenePos();
    if (!verticalStickyMode) {
        if (closeEnough(itemPos.x(), target.x(), stickyDistance)) {  // enter stickyMode
            verticalStickyMode = true;
            verticalStickPoint = mousePos;
            item->setFlag(QGraphicsItem::ItemIsMovable, false);
            item->setPos(QPointF(target.x(), itemPos.y()));
        }
    }
    if (!horizontalStickyMode) {
        if (closeEnough(itemPos.y(), target.y(), stickyDistance)) {
            horizontalStickyMode = true;
            horizontalStickPoint = mousePos;
            item->setFlag(QGraphicsItem::ItemIsMovable, false);
            item->setPos(QPointF(itemPos.x(), target.y()));
        }
    }
}

/**
 * Режим разгруппировки элементов
 */
void DiagramScene::tryLeavingStickyMode(QGraphicsItem* item, const QPointF& mousePos) {
    if (verticalStickyMode) {
        item->moveBy(0, mousePos.y() - verticalStickPoint.y());
        verticalStickPoint.setY(mousePos.y());

        if (!closeEnough(mousePos.x(), verticalStickPoint.x(), stickyDistance)) {
            verticalStickyMode = false;
            item->setFlag(QGraphicsItem::ItemIsMovable, true);
        }
    }
    if (horizontalStickyMode) {
        item->moveBy(mousePos.x() - horizontalStickPoint.x(), 0);
        horizontalStickPoint.setX(mousePos.x());

        if (!closeEnough(mousePos.y(), horizontalStickPoint.y(), stickyDistance)) {
            horizontalStickyMode = false;
            item->setFlag(QGraphicsItem::ItemIsMovable, true);
        }
    }
}

