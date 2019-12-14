class Canvas::Private
{
public:
    Private() :
        tabIndex(-1),
        view(nullptr)
    {}

    qreal round(qreal val, int step)
    {
       int tmp = int(val) + step /2;
       tmp -= tmp % step;
       return qreal(tmp);
    }

    int            tabIndex;
    QGraphicsView* view;
    CanvasManager *mCanvasManager;
};

Canvas::Canvas(QObject *parent)
    : QGraphicsScene(parent), d(new Private)
{
    d->view = new QGraphicsView(this);
    d->view->setSceneRect(0,0,CANVAS_WIDTH,CANVAS_HEIGHT);

    d->mCanvasManager = new CanvasManager(parent, this);
    d->view->verticalScrollBar()->setValue(CANVAS_HEIGHT/3);
    d->view->horizontalScrollBar()->setValue(CANVAS_WIDTH/3);
}

Canvas::~Canvas()
{
    delete d;
}

QGraphicsView* Canvas::view()
{
    return d->view;
}

int Canvas::tabIndex() const
{
    return d->tabIndex;
}

void Canvas::setTabIndex(int index)
{

    d->tabIndex = index;
}

CanvasManager *Canvas::canvasManager()
{
    return d->mCanvasManager;
}

void Canvas::setManager(CanvasManager *manager)
{
    if(manager)
    {
        d->mCanvasManager = manager;
        d->mCanvasManager->setCanvas(this);
    }
}

} // namespace Logicsim

