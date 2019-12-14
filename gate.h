#ifndef GATE_H
#define GATE_H

// Local includes

#include "component.h"
#include "pin.h"

namespace Logicsim
{

class Gate : public Component
{
    Q_OBJECT
public:
    ~Gate();

    qint16 maxInput();

    void mouseMoveEvent(QGraphicsSceneMouseEvent *event);
    void paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget);

    QRectF boundingRect() const;
    void updateConnection();

#endif // GATE_H
