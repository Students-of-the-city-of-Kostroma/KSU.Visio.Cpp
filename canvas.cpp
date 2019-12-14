
void Canvas::keyPressEvent(QKeyEvent *event)
{
    switch (event->key())
    {
        case Qt::Key_Delete:
        if(d->mCanvasManager->selectedComponentIndex() != -1)
        {

            d->mCanvasManager->deleteComponent(d->mCanvasManager->selectedComponentIndex());
        }
        else if(d->mCanvasManager->selectedLineIndex() != -1)
        {

            d->mCanvasManager->deleteLine(d->mCanvasManager->selectedLineIndex());
        }
        break;
    }
}

void Canvas::mousePressEvent(QGraphicsSceneMouseEvent *event)
{
    QGraphicsScene::mousePressEvent(event);
    d->mCanvasManager->unSelectComponent();
    d->mCanvasManager->unSelectLine();
    if(mouseGrabberItem() != nullptr)
    {
        Pin* p = dynamic_cast<Pin*>(mouseGrabberItem());
        if(p)
        {
            d->mCanvasManager->pinPressed(p);
        }
    }
    else
    {
        d->mCanvasManager->unSelectPins();
    }
    Canvas::mouseMoveEvent(event);
}

void Canvas::mouseMoveEvent(QGraphicsSceneMouseEvent *event)
{
    if(mouseGrabberItem() != nullptr)
    {
        Component *component = dynamic_cast<Component*>(mouseGrabberItem());
        if(component)
        {
            d->mCanvasManager->selectComponent(component);
            d->mCanvasManager->movingComponent(component);
            if(!d->mCanvasManager->isDropable(event->scenePos())
                    || d->mCanvasManager->isOutOfCanvas(event->scenePos()))
            {
                d->view->setCursor(Qt::ForbiddenCursor);
            }
            else
            {
                d->view->setCursor(Qt::ClosedHandCursor);
            }
        }
    }
    QGraphicsScene::mouseMoveEvent(event);
}

void Canvas::mouseReleaseEvent(QGraphicsSceneMouseEvent *event)
{
    if(mouseGrabberItem() != nullptr)
    {
        Component *component = dynamic_cast<Component*>(mouseGrabberItem());
        if(component)
        {
            d->mCanvasManager->movingComponent(component);
            d->mCanvasManager->componentMoved(component, event->scenePos());
            d->view->setCursor(Qt::ArrowCursor);
        }
    }
    QGraphicsScene::mouseReleaseEvent(event);
}

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

