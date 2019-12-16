#include "diagramelement.h"
#include "arrow.h"
#include <QGraphicsScene>
#include <QGraphicsSceneContextMenuEvent>
#include <QMenu>
#include <QPainter>
#include <QDebug>
#include <QStyleOptionGraphicsItem>


DiagramElement::DiagramElement(DiagramType diagramType, QMenu *contextMenu,
             QGraphicsItem *parent)
    : QGraphicsPolygonItem(parent)
{
    myDiagramType = diagramType;
    myContextMenu = contextMenu;

    QPainterPath path;
    /**
     * Рисование объектов
     */
    switch (myDiagramType) {
        case StartEnd:
            path.moveTo(200, 50);
            path.arcTo(150, 0, 50, 50, 0, 90);
            path.arcTo(50, 0, 50, 50, 90, 90);
            path.arcTo(50, 50, 50, 50, 180, 90);
            path.arcTo(150, 50, 50, 50, 270, 90);
            path.lineTo(200, 50);
            myPolygon = path.toFillPolygon().translated(-125, -50);
            break;
        case Conditional:
            myPolygon << QPointF(-100, -100) << QPointF(100, -100)
                      << QPointF(100, 100) << QPointF(-100, 100)
                      << QPointF(-100, -100);
            break;
        case Step:
            myPolygon << QPointF(-100, -100) << QPointF(100, -100)
                      << QPointF(100, 100) << QPointF(-100, 100)
                      << QPointF(-100, -100)<<QPointF(-100, -30)<<QPointF(100, -30)
                         <<QPointF(100, -100)<<QPointF(-100,-100);
            break;
    }
    setPolygon(myPolygon);
    setFlag(QGraphicsItem::ItemIsMovable, true);
    setFlag(QGraphicsItem::ItemIsSelectable, true);
    setFlag(QGraphicsItem::ItemSendsGeometryChanges, true);
    setAcceptHoverEvents(true);
}

/**
 * Удаление стрелки
 */
void DiagramElement::removeArrow(Arrow *arrow)
{
    int index = arrows.indexOf(arrow);

    if (index != -1)
        arrows.removeAt(index);
}

void DiagramElement::removeArrows()
{
    foreach (Arrow *arrow, arrows) {
        arrow->startItem()->removeArrow(arrow);
        arrow->endItem()->removeArrow(arrow);
        scene()->removeItem(arrow);
        delete arrow;
    }
}

/**
 * Создание стрелки
 */
void DiagramElement::addArrow(Arrow *arrow)
{
    arrows.append(arrow);
}

QPixmap DiagramElement::image() const
{
    QPixmap pixmap(250, 250);
    pixmap.fill(Qt::transparent);
    QPainter painter(&pixmap);
    painter.setPen(QPen(Qt::black, 8));
    painter.translate(125, 125);
    painter.drawPolyline(myPolygon);
    return pixmap;
}

/**
 * Маркер изменения точек границы
 */
QList<QPointF> DiagramElement::resizeHandlePoints() {
    qreal width = resizeHandlePointWidth;
    QRectF rf = QRectF(boundingRect().topLeft() + QPointF(width/2, width/2),
                           boundingRect().bottomRight() - QPointF(width/2, width/2));
    qreal centerX = rf.center().x();
    qreal centerY = rf.center().y();
    return QList<QPointF>{rf.topLeft(), QPointF(centerX, rf.top()), rf.topRight(),
                         QPointF(rf.left(), centerY), QPointF(rf.right(), centerY),
                rf.bottomLeft(), QPointF(centerX, rf.bottom()), rf.bottomRight()};
}

bool DiagramElement::isCloseEnough(QPointF const& p1, QPointF const& p2) {
    qreal delta = std::abs(p1.x() - p2.x()) + std::abs(p1.y() - p2.y());
    return delta < closeEnoughDistance;
}

/**
 * Копирование
 */
DiagramElement* DiagramElement::clone() {
    DiagramElement* cloned = new DiagramElement(myDiagramType, myContextMenu, nullptr);
    cloned->myPolygon = myPolygon;
    cloned->setPos(scenePos());
    cloned->setPolygon(myPolygon);
    cloned->setBrush(brush());
    cloned->setZValue(zValue());
    return cloned;
}

/**
 * Обработка события нажатия мыши
 */
void DiagramElement::mousePressEvent(QGraphicsSceneMouseEvent* event) {
    resizeMode = false;
    int index = 0;
    foreach (QPointF const& p, resizeHandlePoints()) {
        if (isCloseEnough(event->pos(), p)) {
            resizeMode = true;
            break;
        }
        index++;
    }
    scaleDirection = static_cast<Direction>(index);
    setFlag(GraphicsItemFlag::ItemIsMovable, !resizeMode);
    if (resizeMode) {
        previousPolygon = polygon();
        event->accept();
    } else {
        movingStartPosition = scenePos();
        QGraphicsItem::mousePressEvent(event);
    }
}

/**
 * Обработка события перемещения мыши
 */
void DiagramElement::mouseMoveEvent(QGraphicsSceneMouseEvent* event) {
    if (resizeMode) {
        prepareGeometryChange();
        myPolygon = scaledPolygon(myPolygon, scaleDirection, event->pos());
        setPolygon(myPolygon);
    }
    QGraphicsItem::mouseMoveEvent(event);
}

/**
 * Обработка события отпускания мыши
 */
void DiagramElement::mouseReleaseEvent(QGraphicsSceneMouseEvent* event) {
    if (resizeMode) {
        if (polygon() != previousPolygon) {
            isResized = true;
        }
    } else {
        if (scenePos() != movingStartPosition) {
            isMoved = true;
        }
    }
    resizeMode = false;
    QGraphicsItem::mouseReleaseEvent(event);
}

/**
 * Обработка события перемещения при наведении курсора
 */
void DiagramElement::hoverMoveEvent(QGraphicsSceneHoverEvent* event) {
    setCursor(Qt::ArrowCursor);
    int index = 0;
    foreach (QPointF const& p, resizeHandlePoints()) {
        if (isCloseEnough(p, event->pos())) {
            switch (static_cast<Direction>(index)) {
            case TopLeft:
            case BottomRight: setCursor(Qt::SizeFDiagCursor); break;
            case Top:
            case Bottom: setCursor(Qt::SizeVerCursor); break;
            case TopRight:
            case BottomLeft: setCursor(Qt::SizeBDiagCursor); break;
            case Left:
            case Right: setCursor(Qt::SizeHorCursor); break;
            }
            break;
        }
        index++;
    }
    QGraphicsItem::hoverMoveEvent(event);
}

/**
 * Рисование объектов
 */
void DiagramElement::paint(QPainter* painter, const QStyleOptionGraphicsItem* option,
                        QWidget* widget) {
    QStyleOptionGraphicsItem myOption(*option);
    myOption.state &= ~QStyle::State_Selected;
    QGraphicsPolygonItem::paint(painter, &myOption, widget);

    if (this->isSelected()) {
        qreal width = resizeHandlePointWidth;
        foreach(QPointF const& point, resizeHandlePoints()) {
            painter->drawEllipse(QRectF(point.x() - width/2, point.y() - width/2, width, width));
        }
    }
}


void DiagramElement::contextMenuEvent(QGraphicsSceneContextMenuEvent *event)
{
    scene()->clearSelection();
    setSelected(true);
    myContextMenu->exec(event->screenPos());
}

/**
 * Изменение элемента
 */
QVariant DiagramElement::itemChange(GraphicsItemChange change, const QVariant &value)
{
    if (change == QGraphicsItem::ItemPositionChange) {
        foreach (Arrow *arrow, arrows) {
            arrow->updatePosition();
        }
    }

    return value;
}

/**
 * Масштабирование элемента
 */
QPolygonF DiagramElement::scaledPolygon(const QPolygonF& old, DiagramElement::Direction direction,
                                    const QPointF& newPos) {
    qreal oldWidth = old.boundingRect().width();
    qreal oldHeight = old.boundingRect().height();
    qreal scaleWidth, scaleHeight;
    switch(direction) {
    case TopLeft: {
        QPointF fixPoint = old.boundingRect().bottomRight();
        scaleWidth = (fixPoint.x() - newPos.x()) / oldWidth;
        scaleHeight = (fixPoint.y() - newPos.y()) / oldHeight;
        break;
    }
    case Top: {
        QPointF fixPoint = old.boundingRect().bottomLeft();
        scaleWidth = 1;
        scaleHeight = (fixPoint.y() - newPos.y()) / oldHeight;
        break;
    }
    case TopRight: {
        QPointF fixPoint = old.boundingRect().bottomLeft();
        scaleWidth = (newPos.x() - fixPoint.x()) / oldWidth;
        scaleHeight = (fixPoint.y() - newPos.y() ) / oldHeight;
        break;
    }
    case Right: {
        QPointF fixPoint = old.boundingRect().bottomLeft();
        scaleWidth = (newPos.x() - fixPoint.x()) / oldWidth;
        scaleHeight = 1;
        break;
    }
    case BottomRight: {
        QPointF fixPoint = old.boundingRect().topLeft();
        scaleWidth = (newPos.x() - fixPoint.x()) / oldWidth;
        scaleHeight = (newPos.y() - fixPoint.y()) / oldHeight;
        break;
    }
    case Bottom: {
        QPointF fixPoint = old.boundingRect().topLeft();
        scaleWidth = 1;
        scaleHeight = (newPos.y() - fixPoint.y()) / oldHeight;
        break;
    }
    case BottomLeft: {
        QPointF fixPoint = old.boundingRect().topRight();
        scaleWidth = (fixPoint.x() - newPos.x()) / oldWidth;
        scaleHeight = (newPos.y() - fixPoint.y()) / oldHeight;
        break;
    }
    case Left: {
        QPointF fixPoint = old.boundingRect().bottomRight();
        scaleWidth = (fixPoint.x() - newPos.x()) / oldWidth;
        scaleHeight = 1;
        break;
    }
    }
    QTransform trans;
    trans.scale(scaleWidth, scaleHeight);
    return trans.map(old);
}

