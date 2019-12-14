#include "gates.h"
#include <string>

// Qt includes

#include <QDebug>
#include <QPainter>

namespace Logicsim
{

// ===================== AndGate ===================

AndGate::AndGate()
    :Gate(Component::AndGate)
{
    setMetaTypeId(qRegisterMetaType<AndGate>("AndGate"));
    setToolTip("And Gate");
}

AndGate::AndGate(const AndGate &g)
    : Gate(g.componentType())
{
}

QRectF AndGate::boundingRect() const
{
    return Component::boundingRect();
}

void AndGate::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget)
{
    Gate::paint(painter, option, widget);
    QPainterPath path(QPointF(0,0));
    path.lineTo(40, 0);
    path.lineTo(40,50);
    path.lineTo(0,50);
    path.lineTo(0,0);
    QFont font("Helvetica [Cronyx]");
    font.setPixelSize(25);
    font.setBold(true);
    path.addText(QPointF(12, 33),font,tr("&"));
    painter->drawPath(path);
}

void AndGate::calcOutput()
{
    Pin::Value out_logic;

    if(in1()->value() == Pin::True && in2()->value() == Pin::True)
    {
        out_logic = Pin::True;
    }
    else if(in1()->value() == Pin::Undefined || in2()->value() == Pin::Undefined)
    {
        out_logic = Pin::Undefined;
    }
    else
    {
        out_logic = Pin::False;
    }

    emit outputChanged(out_logic);
}

QString AndGate::imageUrl() const
{
    return QString(":/gates/and");
}

// ===================== OrGate ===================


OrGate::OrGate()
    : Gate(Component::OrGate)
{
    setMetaTypeId(qRegisterMetaType<OrGate>("OrGate"));
    setToolTip("Or Gate");
}

OrGate::OrGate(const OrGate &g)
    : Gate(g.componentType())
{
}

void OrGate::calcOutput()
{
    Pin::Value out_logic;

    if(in1()->value() == Pin::False && in2()->value() == Pin::False)
    {
        out_logic = Pin::False;
    }
    else if(in1()->value() == Pin::True || in2()->value() == Pin::True)
    {
        out_logic = Pin::True;
    }
    else
    {
        out_logic = Pin::Undefined;
    }


    emit outputChanged(out_logic);
}

QString OrGate::imageUrl() const
{
    return QString(":/gates/or");
}

QRectF OrGate::boundingRect() const
{
    return Component::boundingRect();
}

void OrGate::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget)
{
    Gate::paint(painter, option, widget);
    QPainterPath path;
    path.lineTo(40, 0);
    path.lineTo(40,50);
    path.lineTo(0,50);
    path.lineTo(0,0);
    QFont font("Helvetica [Cronyx]");
    font.setPixelSize(25);
    font.setBold(true);
    path.addText(QPointF(12, 33),font,tr("1"));
    painter->drawPath(path);
}



// ===================== NotGate ===================

NotGate::NotGate()
    : Gate(Component::NotGate)
{
    setMaxInput(1);
    setMetaTypeId(qRegisterMetaType<NotGate>("NotGate"));
    setToolTip("Not Gate");
}

NotGate::NotGate(const NotGate &g)
    : Gate(g.componentType())
{
}

void NotGate::calcOutput()
{
    Pin::Value out_logic;
    if(in1()->value() == Pin::False)
    {
        out_logic = Pin::True;
    }
    else if(in1()->value() == Pin::True)
    {
        out_logic = Pin::False;
    }
    else
    {
        out_logic = Pin::Undefined;
    }
    emit outputChanged(out_logic);
}

QString NotGate::imageUrl() const
{
    return QString(":/gates/not");
}

QRectF NotGate::boundingRect() const
{
    return Component::boundingRect();
}

void NotGate::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget)
{
    Gate::paint(painter, option, widget);
    QPainterPath path(QPointF(0,0));
    path.lineTo(40, 0);
    path.lineTo(40,50);
    path.lineTo(0,50);
    path.lineTo(0,0);
    QFont font("Helvetica [Cronyx]");
    font.setPixelSize(25);
    font.setBold(true);
    path.addText(QPointF(12, 33),font,tr("1"));
    painter->drawPath(path);
}

// ===================== NandGate ===================

NandGate::NandGate()
    : Gate(Component::NandGate)
{
    setMetaTypeId(qRegisterMetaType<NandGate>("NandGate"));
    setToolTip("Nand Gate");
}

NandGate::NandGate(const NandGate &g)
    : Gate(g.componentType())
{
}

void NandGate::calcOutput()
{
    Pin::Value out_logic;

    if(in1()->value() == Pin::True && in2()->value() == Pin::True)
    {
        out_logic = Pin::True;
    }
    else if(in1()->value() == Pin::Undefined || in2()->value() == Pin::Undefined)
    {
        out_logic = Pin::Undefined;
    }
    else
    {
        out_logic = Pin::False;
    }

    if(out_logic == Pin::False)
    {
        out_logic = Pin::True;
    }
    else if(out_logic == Pin::True)
    {
        out_logic = Pin::False;
    }
    else
    {
        out_logic = Pin::Undefined;
    }

    //outputNode()->setValue(!out);
    emit outputChanged(out_logic);
}

QString NandGate::imageUrl() const
{
    return QString(":/gates/nand");
}


void NandGate::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget)
{
    Gate::paint(painter, option, widget);
    QPainterPath path(QPointF(0,0));
    path.lineTo(40, 0);
    path.lineTo(40,50);
    path.lineTo(0,50);
    path.lineTo(0,0);
    QFont font("Helvetica [Cronyx]");
    font.setPixelSize(25);
    font.setBold(true);
    path.addText(QPointF(14, 15),font,tr("-"));
    path.addText(QPointF(12, 33),font,tr("&"));
    painter->drawPath(path);
}

// ===================== NorGate ===================

NorGate::NorGate()
    : Gate(Component::NorGate)
{
    setMetaTypeId(qRegisterMetaType<NorGate>("NorGate"));
    setToolTip("Nor Gate");
}

NorGate::NorGate(const NorGate &g)
    : Gate(g.componentType())
{
}

void NorGate::calcOutput()
{
    Pin::Value out_logic;

    if(in1()->value() == Pin::False && in2()->value() == Pin::False)
    {
        out_logic = Pin::False;
    }
    else if(in1()->value() == Pin::True || in2()->value() == Pin::True)
    {
        out_logic = Pin::True;
    }
    else
    {
        out_logic = Pin::Undefined;
    }
    if(out_logic == Pin::False)
    {
        out_logic = Pin::True;
    }
    else if(out_logic == Pin::True)
    {
        out_logic = Pin::False;
    }
    else
    {
        out_logic = Pin::Undefined;
    }



    //outputNode()->setValue(!out);
    emit outputChanged(out_logic);
}

QString NorGate::imageUrl() const
{
    return QString(":/gates/nor");
}

void NorGate::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget)
{
    Gate::paint(painter, option, widget);
    QPainterPath path;
    path.lineTo(40, 0);
    path.lineTo(40,50);
    path.lineTo(0,50);
    path.lineTo(0,0);
    QFont font("Helvetica [Cronyx]");
    font.setPixelSize(25);
    font.setBold(true);
    path.addText(QPointF(14, 15),font,tr("-"));
    path.addText(QPointF(12, 33),font,tr("1"));
    painter->drawPath(path);
}



} // namespace Logicsim
