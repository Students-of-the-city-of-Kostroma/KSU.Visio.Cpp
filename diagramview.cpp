#include "diagramview.h"
#include <QKeyEvent>
#include <QDebug>
#include "diagramelement.h"
#include "diagramtext.h"

DiagramView::DiagramView(QGraphicsScene* scene, QWidget* parent)
    : QGraphicsView(scene, parent) {
    setRenderHints(QPainter::Antialiasing | QPainter::TextAntialiasing);
    setDragMode(QGraphicsView::RubberBandDrag);
}

/**
 * Обработка события нажатия кнопки
 */
void DiagramView::keyPressEvent(QKeyEvent* event) {
    if ((event->modifiers() & Qt::KeyboardModifier::ControlModifier) != 0) {
        setDragMode(DragMode::ScrollHandDrag);
    }
    QGraphicsView::keyPressEvent(event);
}

/**
 * Обработка события отпускания кнопки
 */
void DiagramView::keyReleaseEvent(QKeyEvent* event) {
    if ((event->modifiers() & Qt::KeyboardModifier::ControlModifier) == 0) {
        setDragMode(DragMode::RubberBandDrag);
    }
}
/**
 * Обработка события отпускания мыши
 */
void DiagramView::mouseReleaseEvent(QMouseEvent* event) {
    QGraphicsView::mouseReleaseEvent(event);
    bool needsEmit = false;
    foreach(QGraphicsItem* item, scene()->selectedItems()) {
        if (item->type() == DiagramElement::Type) {
            DiagramElement* p = qgraphicsitem_cast<DiagramElement*>(item);
            if (p->isMoved) {
                needsEmit = true;
                p->isMoved = false;
            }
            if (p->isResized) {
                needsEmit = true;
                p->isResized = false;
            }
        } else if (item->type() == DiagramText::Type) {
            DiagramText* p = qgraphicsitem_cast<DiagramText*>(item);
            if (p->positionIsUpdated()) {
                needsEmit = true;
                p->setUpdated();
            }
        }
    }
    if (needsEmit) emit needsUndoBackup();
}

