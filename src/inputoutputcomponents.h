#ifndef INPUTOUTPUTCOMPONENTS
#define INPUTOUTPUTCOMPONENTS

// Qt includes

#include <QtWidgets>

// Local includes

#include "pin.h"
#include "component.h"
#include "logicsim_global.h"

namespace Logicsim
{
class InputComponent : public Component
{
public:
    InputComponent();
    InputComponent(const InputComponent& g);
    ~InputComponent();

    QRectF boundingRect() const;
    QString imageUrl() const;

    void updateConnection();

    void paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget = nullptr);
    void mouseMoveEvent(QGraphicsSceneMouseEvent *event);
    void mouseDoubleClickEvent(QGraphicsSceneMouseEvent *event);

private:
//    Node *pnode;
    Pin* m_pin;
};

// ==============================================

class OutputComponent : public Component
{
public:
    OutputComponent();
    OutputComponent(const OutputComponent& g);
    ~OutputComponent();

    QRectF boundingRect() const;
    QString imageUrl() const;

    void updateConnection();

    void paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget = nullptr);
    void mouseMoveEvent(QGraphicsSceneMouseEvent *event);
    void mouseDoubleClickEvent(QGraphicsSceneMouseEvent *event);

private:
//    Node *pnode;
    Pin* m_pin;
};

}

#endif // INPUTOUTPUTCOMPONENTS

