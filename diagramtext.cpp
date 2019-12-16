#include "diagramtext.h"
#include "diagramscene.h"
#include <QDebug>
#include <QTextCursor>

DiagramText::DiagramText(QGraphicsItem *parent)
    : QGraphicsTextItem(parent)
{
    setFlag(QGraphicsItem::ItemIsMovable);
    setFlag(QGraphicsItem::ItemIsSelectable);
    positionLastTime = QPointF(0, 0);
}

/**
 * Копировать
 */
DiagramText* DiagramText::clone() {
    DiagramText* cloned = new DiagramText(nullptr);
    cloned->setPlainText(toPlainText());
    cloned->setFont(font());
    cloned->setTextWidth(textWidth());
    cloned->setDefaultTextColor(defaultTextColor());
    cloned->setPos(scenePos());
    cloned->setZValue(zValue());
    return cloned;
}

/**
 * Изменение элемента
 */
QVariant DiagramText::itemChange(GraphicsItemChange change,
                     const QVariant &value)
{
    if (change == QGraphicsItem::ItemSelectedHasChanged)
        emit selectedChange(this);
    return value;
}

void DiagramText::focusInEvent(QFocusEvent* event) {
       if (positionLastTime == QPointF(0, 0))
        positionLastTime = scenePos();
    QGraphicsTextItem::focusInEvent(event);
}

void DiagramText::focusOutEvent(QFocusEvent *event) {
    setTextInteractionFlags(Qt::NoTextInteraction);
    if (contentLastTime == toPlainText()) {
        contentHasChanged = false;
    } else {
        contentLastTime = toPlainText();
        contentHasChanged = true;
    }
    emit lostFocus(this);
    QGraphicsTextItem::focusOutEvent(event);
}

/**
 * Обработка события двойного щелчка мыши
 */
void DiagramText::mouseDoubleClickEvent(QGraphicsSceneMouseEvent *event) {
    if (textInteractionFlags() == Qt::NoTextInteraction) {
        setTextInteractionFlags(Qt::TextEditorInteraction);
    }
    QGraphicsTextItem::mouseDoubleClickEvent(event);
}

/**
 * Обработка события нажатия мыши
 */
void DiagramText::mousePressEvent(QGraphicsSceneMouseEvent* event) {
    QGraphicsTextItem::mousePressEvent(event);
}

/**
 * Обработка события отпускания мыши
 */
void DiagramText::mouseReleaseEvent(QGraphicsSceneMouseEvent* event) {
    if (scenePos() != positionLastTime) {
        isMoved = true;
    }
    positionLastTime = scenePos();
    QGraphicsTextItem::mouseReleaseEvent(event);
}
