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
