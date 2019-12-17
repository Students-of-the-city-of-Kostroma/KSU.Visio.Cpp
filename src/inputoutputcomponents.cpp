#include <QtWidgets>
#include "pin.h"
#include "pin.h"
#include "component.h"
#include "inputoutputcomponents.h"

namespace Logicsim {

InputComponent::InputComponent()
    : Component(Component::InputComponent), m_pin(0)
{
    setFlag(QGraphicsItem::ItemIsMovable);
    setFlag(QGraphicsItem::ItemSendsGeometryChanges);

    setMetaTypeId(qRegisterMetaType<InputComponent>("InputComponent"));
    m_pin = new Pin(Pin::Output, this);
    m_pin->setPos(40,10);

    addPins(QList<Pin*>() << m_pin);

    QGraphicsLineItem *Li = new QGraphicsLineItem(QLineF(0,0,10,0), m_pin);
    Li->setPos(-10,5);

    m_pin->updatePinValue(Pin::False);

    setToolTip("Input Component");
}

InputComponent::InputComponent(const InputComponent &g)
    : Component(g.componentType())
{
    Q_UNUSED(g);
}

InputComponent::~InputComponent(){}

QRectF InputComponent::boundingRect() const
{
    return QRectF(0,0,30,30);
}

void InputComponent::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget)
{
    QFont font;
    font.setPointSize ( 15 );
    font.setWeight(QFont::DemiBold);

    painter->setRenderHint(QPainter::Antialiasing);
    Component::paint(painter, option, widget);
    if(m_pin->value() == Pin::True)
    {
        painter->setBrush(QColor(0,255,0,180));


        painter->setFont(font);
        painter->drawText(QPointF(9,23),"1");
    }
    else
    {
        painter->setBrush(QColor(255,0,0,180));


        painter->setFont(font);
        painter->drawText(QPointF(9,23),"0");
    }
    painter->drawEllipse(0,0,30,30);
}

QString InputComponent::imageUrl() const
{
    return QString(":/gates/input");
}

void InputComponent::updateConnection()
{
    m_pin->updateConnectedLine();
}

void InputComponent::mouseMoveEvent(QGraphicsSceneMouseEvent *event)
{
    QGraphicsObject::mouseMoveEvent(event);
    m_pin->updateConnectedLine();

}

void InputComponent::mouseDoubleClickEvent(QGraphicsSceneMouseEvent *event)
{
    Q_UNUSED(event)

    (m_pin->value() == Pin::True) ? m_pin->updatePinValue(Pin::False) : m_pin->updatePinValue(Pin::True);
    update();


}

// ==============================================

OutputComponent::OutputComponent()
    : Component(Component::OutputComponent), m_pin(0)
{

    setFlag(QGraphicsItem::ItemIsMovable);
    setFlag(QGraphicsItem::ItemSendsGeometryChanges);

    setMetaTypeId(qRegisterMetaType<OutputComponent>("OutputComponent"));

    m_pin = new Pin(Pin::Input, this);
    m_pin->setPos(-20,10);

    addPins(QList<Pin*>() << m_pin);

    QGraphicsLineItem* Lo = new QGraphicsLineItem(QLineF(0,0,10,0), m_pin);
    Lo->setPos(10,5);

    setToolTip("Output Component");
}

OutputComponent::OutputComponent(const OutputComponent &g): Component(Component::OutputComponent)
{
    Q_UNUSED(g)
}

OutputComponent::~OutputComponent()
{
}

QRectF OutputComponent::boundingRect() const
{
    return QRectF(0,0,30,30);
}

void OutputComponent::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget)
{
    QFont font;
    font.setPointSize ( 15 );
    font.setWeight(QFont::DemiBold);
    painter->setRenderHint(QPainter::Antialiasing);
    Component::paint(painter, option, widget);
    painter->setBrush(Qt::SolidPattern);
    if(m_pin != 0)
    {
        if(!m_pin->isConnected() || m_pin->value() == Pin::Undefined)
        {
            painter->setBrush(QColor(63,63,64,180));
            painter->setFont(font);
            painter->drawText(QPointF(10,23),"-");
        }
        else if(m_pin->value() == Pin::True)
        {
            painter->setBrush(QColor(0,255,0,200));


            painter->setFont(font);
            painter->drawText(QPointF(9,23),"1");

        }
        else if(m_pin->value() == Pin::False)
        {
            painter->setBrush(QColor(255,0,0,200));


            painter->setFont(font);
            painter->drawText(QPointF(9,23),"0");
        }
    }
    painter->drawRect(0,0,30,30);
}

QString OutputComponent::imageUrl() const
{
    return QString(":/gates/output");
}

void OutputComponent::updateConnection()
{
    m_pin->updateConnectedLine();
}

void OutputComponent::mouseMoveEvent(QGraphicsSceneMouseEvent *event)
{
    QGraphicsObject::mouseMoveEvent(event);
    m_pin->updateConnectedLine();

}

void OutputComponent::mouseDoubleClickEvent(QGraphicsSceneMouseEvent *event)
{
    Q_UNUSED(event)


}

} // namespace Logicsim
