void Canvas::dropEvent(QGraphicsSceneDragDropEvent * event)
{
    if(event->mimeData()->property("acceptable").toBool())
    {
        int typeId = event->mimeData()->property("typeId").toInt();
        event->acceptProposedAction();

        Component* component = static_cast<Component*>(QMetaType::create(typeId));
        d->mCanvasManager->addComponent(component, event->scenePos());
    }
    else
    {
        event->setAccepted(false);
    }
}

void Canvas::dragEnterEvent(QGraphicsSceneDragDropEvent * event)
{

    if(event->mimeData()->property("acceptable").toBool())
    {
        event->acceptProposedAction();
    }
    else
    {
        event->setAccepted(false);
    }
}

void Canvas::dragMoveEvent(QGraphicsSceneDragDropEvent * event)
{
    if(event->mimeData()->property("acceptable").toBool())
    {
        if(d->mCanvasManager->isDropable(event->scenePos()))
        {
            event->acceptProposedAction();
        }
        else
        {
            event->setAccepted(false);
        }
    }
    else
    {
        event->setAccepted(false);
    }
}

void Canvas::dragLeaveEvent(QGraphicsSceneDragDropEvent * event)
{
    if(event->mimeData()->property("acceptable").toBool())
    {
        event->acceptProposedAction();
    }
    else
    {
        event->setAccepted(false);
    }
}

