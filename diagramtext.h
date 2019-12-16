#ifndef DIAGRAMTEXT_H
#define DIAGRAMTEXT_H

#include <QGraphicsTextItem>
#include <QPen>

QT_BEGIN_NAMESPACE
class QFocusEvent;
class QGraphicsItem;
class QGraphicsScene;
class QGraphicsSceneMouseEvent;
QT_END_NAMESPACE

class DiagramText : public QGraphicsTextItem
{
    Q_OBJECT

public:
    enum { Type = UserType + 3 };

    DiagramText(QGraphicsItem *parent = nullptr);

    int type() const override { return Type; }

    bool contentIsUpdated() { return contentHasChanged; }
    bool positionIsUpdated() { return isMoved; }
    void setUpdated() { isMoved = false; }
    DiagramText* clone();

signals:
    void lostFocus(DiagramText *item);
    void selectedChange(QGraphicsItem *item);

protected:
    QVariant itemChange(GraphicsItemChange change, const QVariant &value) override;
    void focusInEvent(QFocusEvent* event) override;
    void focusOutEvent(QFocusEvent *event) override;
    void mouseDoubleClickEvent(QGraphicsSceneMouseEvent *event) override;
    void mousePressEvent(QGraphicsSceneMouseEvent *event) override;
    void mouseReleaseEvent(QGraphicsSceneMouseEvent *event) override;

private:
    QString contentLastTime;
    QPointF positionLastTime;
    bool isMoved = false;
    bool contentHasChanged = false;
};

#endif // DIAGRAMTEXT_H
