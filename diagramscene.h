#ifndef DIAGRAMSCENE_H
#define DIAGRAMSCENE_H

#include "diagramelement.h"
#include "diagramtext.h"

#include <QGraphicsScene>

QT_BEGIN_NAMESPACE
class QGraphicsSceneMouseEvent;
class QMenu;
class QPointF;
class QGraphicsLineItem;
class QFont;
class QGraphicsTextItem;
class QColor;
QT_END_NAMESPACE

class DiagramScene : public QGraphicsScene
{
    Q_OBJECT

public:
    enum Mode { InsertItem, InsertLine, InsertText, MoveItem };
    explicit DiagramScene(QMenu *itemMenu, QObject *parent = nullptr);
    QFont font() const { return myFont; }
    void setFont(const QFont &font);
    void deleteItems(QList<QGraphicsItem*> const& items);

public slots:
    void setMode(Mode mode);
    void setItemType(DiagramElement::DiagramType type);
    void editorLostFocus(DiagramText *item);

signals:
    void itemInserted(DiagramElement *item);
    void textInserted(QGraphicsTextItem *item);
    void textChanged();
    void arrowInserted();
    void itemSelected(QGraphicsItem *item);
    void scaleChanging(int delta);

protected:
    void mousePressEvent(QGraphicsSceneMouseEvent *mouseEvent) override;
    void mouseMoveEvent(QGraphicsSceneMouseEvent *mouseEvent) override;
    void mouseReleaseEvent(QGraphicsSceneMouseEvent *mouseEvent) override;
    void wheelEvent(QGraphicsSceneWheelEvent* wheelEvent) override;

private:
    void mouseDraggingMoveEvent(QGraphicsSceneMouseEvent* event);
    void clearOrthogonalLines();
    inline bool closeEnough(qreal x, qreal y, qreal delta);
    enum LineAttr { Other = 0, Horizontal, Vertical, Both};

    LineAttr getPointsRelationship(QPointF const& p1, QPointF const& p2);
    void tryEnteringStickyMode(QGraphicsItem* item, QPointF const& target, QPointF const& mousePos);
    void tryLeavingStickyMode(QGraphicsItem* item, QPointF const& mousePos);

    DiagramElement::DiagramType myItemType;
    QMenu *myItemMenu;
    Mode myMode;
    QPointF startPoint;
    QGraphicsLineItem *line;
    QFont myFont;
    DiagramText *textItem;

    bool horizontalStickyMode = false;
    bool verticalStickyMode = false;
    QPointF horizontalStickPoint;
    QPointF verticalStickPoint;
    QList<QGraphicsLineItem*> orthogonalLines;

    bool hasItemSelected = false;

    static const QPen penForLines;
    static constexpr qreal Delta = 0.1;
    static constexpr qreal stickyDistance = 5;
};

#endif // DIAGRAMSCENE_H
