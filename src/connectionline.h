#ifndef CONNECTIONLINE_H
#define CONNECTIONLINE_H

// Qt includes

#include <QGraphicsLineItem>
#include <QObject>

// Local includes

#include "pin.h"

namespace Logicsim
{

class Pin;

class ConnectionLine : public QObject, public QGraphicsLineItem
{
    Q_OBJECT
public:
    ConnectionLine(Pin* out, Pin* in, QGraphicsItem* parent=nullptr);
    ~ConnectionLine();

    Pin* input() const;
    void setInputPin(Pin * in);

    Pin* output() const;
    void setOutputPin(Pin * out);

    void paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget);
    void mousePressEvent(QGraphicsSceneMouseEvent *event);

public Q_SLOTS:
    void updateColor();
    void disconnectPins();

Q_SIGNALS:
    void lineSelected();
    void lineDeleted();

private:
    Pin* m_out;
    Pin* m_in;
};

} // namespace Logicsim

#endif // CONNECTIONLINE_H
