#include "gate.h"

// Qt includes

#include <QPainter>

// Local includes

#include "pin.h"
#include "logicsim_global.h"

namespace Logicsim
{

class Gate::Private
{

qint16 Gate::maxInput()
{
    return d->maxInput;
}



void Gate::mouseMoveEvent(QGraphicsSceneMouseEvent *event)
{
    QGraphicsObject::mouseMoveEvent(event);
    updateConnection();

}

void Gate::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget)
{
    Component::paint(painter, option, widget);
}

QRectF Gate::boundingRect() const
{
    return QRectF(0,0,40,50);
}

void Gate::updateConnection()
{
    d->in1->updateConnectedLine();
    d->out->updateConnectedLine();
    if(maxInput() > 1)
        d->in2->updateConnectedLine();
}

} // namespace Logicsim
