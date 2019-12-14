#include "mainwindow.h"
#include <QtWidgets>

const int InsertTextButton = 10;

MainWindow::MainWindow()
{
    createActions();
    createMenus();
    createToolbars();
    createToolBox();
}

/**
 * Создание действий:
 *      deleteAction     - удалить элемент диаграммы
 *      saveAction       - сохранить диаграмму
 *      exitAction       - выйти из приложения
 *      boldAction       - полужирный шрифт
 *      italicAction     - наклонный шрифт
 *      underlineAction  - подчеркнутый шрифт
 *      aboutAction      - справка
 *      copyAction       - копировать элемент диаграммы
 *      pasteAction      - вставить элемент диаграммы
 *      cutAction        - вырезать элемент диаграммы
 *      groupAction      - группировать элементы диаграммы
 *      ungroupAction    - разгруппировать элементы диаграммы
 * К действиям приклеиваем картинки и сочетания клавиш
 */
void MainWindow::createActions()
{
    deleteAction = new QAction(QIcon(":/images/delete.png"), tr("Удалить"), this);
    deleteAction->setShortcut(tr("Удалить"));
    deleteAction->setStatusTip(tr("Удалить элемент из диграммы"));
    connect(deleteAction, SIGNAL(triggered()), this, SLOT(deleteItem()));

    saveAction = new QAction(QIcon(":/images/save.png"),tr("Сохранить"), this);
    saveAction->setShortcuts(QKeySequence::Quit);
    saveAction->setStatusTip(tr("Сохранить"));
    connect(saveAction, SIGNAL(triggered()), this, SLOT(save()));

    exitAction = new QAction(QIcon(":/images/exit.png"),tr("Выйти"), this);
    exitAction->setShortcuts(QKeySequence::Quit);
    exitAction->setStatusTip(tr("Выйти из программы"));
    connect(exitAction, SIGNAL(triggered()), this, SLOT(close()));

    boldAction = new QAction(tr("Полужирный"), this);
    boldAction->setCheckable(true);
    QPixmap pixmap(":/images/bold.png");
    boldAction->setIcon(QIcon(pixmap));
    boldAction->setShortcut(tr("Ctrl+B"));
    connect(boldAction, SIGNAL(triggered()), this, SLOT(handleFontChange()));

    italicAction = new QAction(QIcon(":/images/italic.png"), tr("Курсив"), this);
    italicAction->setCheckable(true);
    italicAction->setShortcut(tr("Ctrl+I"));
    connect(italicAction, SIGNAL(triggered()), this, SLOT(handleFontChange()));

    underlineAction = new QAction(QIcon(":/images/underline.png"), tr("Подчеркивание"), this);
    underlineAction->setCheckable(true);
    underlineAction->setShortcut(tr("Ctrl+U"));
    connect(underlineAction, SIGNAL(triggered()), this, SLOT(handleFontChange()));

    aboutAction = new QAction(tr("Справка"), this);
    aboutAction->setShortcut(tr("F1"));
    connect(aboutAction, SIGNAL(triggered()), this, SLOT(about()));

    copyAction = new QAction(QIcon(":/images/copy.png"), tr("Копировать"), this);
    copyAction->setShortcut(tr("Ctrl+C"));
    copyAction->setStatusTip(tr("Копировать элемент диаграммы"));
    connect(copyAction, SIGNAL(triggered()), this, SLOT(copyItem()));

    pasteAction = new QAction(QIcon(":/images/paste.png"), tr("Вставить"), this);
    pasteAction->setShortcut(tr("Ctrl+V"));
    pasteAction->setStatusTip(tr("Вставка элементов в диаграмму"));
    connect(pasteAction, SIGNAL(triggered()), this, SLOT(pasteItem()));

    cutAction = new QAction(QIcon(":/images/cut.png"), tr("Вырезать"), this);
    cutAction->setShortcut(tr("Ctrl+X"));
    cutAction->setStatusTip(tr("Вырезать элемент диаграммы"));
    connect(cutAction, SIGNAL(triggered()), this, SLOT(cutItem()));

    groupAction = new QAction(QIcon(":images/group.png"), tr("Группировка"), this);
    groupAction->setStatusTip(tr("Группировка графических элементов"));
    connect(groupAction, SIGNAL(triggered()), this, SLOT(groupItems()));

    ungroupAction = new QAction(QIcon(":images/ungroup.png"), tr("Разгруппировать"), this);
    ungroupAction->setStatusTip(tr("Разгруппировать графические элементы"));
    connect(ungroupAction, SIGNAL(triggered()), this, SLOT(ungroupItems()));
}


/**
 * Создание Главого меню:
 *  - Файл
 *  - Правка
 *  - Справка
 */
void MainWindow::createMenus()
{
    fileMenu = menuBar()->addMenu(tr("Файл"));
    fileMenu->addAction(saveAction);
    fileMenu->addSeparator();
    fileMenu->addAction(exitAction);

    itemMenu = menuBar()->addMenu(tr("Правка"));
    itemMenu->addAction(copyAction);
    itemMenu->addAction(cutAction);
    itemMenu->addAction(pasteAction);
    itemMenu->addSeparator();
    itemMenu->addAction(deleteAction);
    itemMenu->addSeparator();
    itemMenu->addAction(groupAction);
    itemMenu->addAction(ungroupAction);
    itemMenu->addSeparator();

    aboutMenu = menuBar()->addMenu(tr("Справка"));
    aboutMenu->addAction(aboutAction);
}

/**
 * Создание Панели инструментов:
 *  - Редактировать
 *  - Шрифт
 *  - Курсор
 */
void MainWindow::createToolbars()
{
    editToolBar = addToolBar(tr("Редактировать"));
    editToolBar->addAction(copyAction);
    editToolBar->addAction(cutAction);
    editToolBar->addAction(pasteAction);
    editToolBar->addAction(deleteAction);
    editToolBar->addAction(groupAction);
    editToolBar->addAction(ungroupAction);
    removeToolBar(editToolBar);
    addToolBar(Qt::TopToolBarArea , editToolBar);
    editToolBar->show();

    fontCombo = new QFontComboBox();
    connect(fontCombo, SIGNAL(currentFontChanged(QFont)),
            this, SLOT(currentFontChanged(QFont)));
    fontCombo->setEditable(false);

    fontSizeCombo = new QComboBox;
    fontSizeCombo->setEditable(true);
    for (int i = 8; i < 30; i = i + 2)
        fontSizeCombo->addItem(QString().setNum(i));
    QIntValidator *validator = new QIntValidator(2, 64, this);
    fontSizeCombo->setValidator(validator);
    connect(fontSizeCombo, SIGNAL(currentIndexChanged(QString)),
            this, SLOT(fontSizeChanged(QString)));


    textToolBar = addToolBar(tr("Шрифт"));
    textToolBar->addWidget(fontSizeCombo);
    textToolBar->addAction(boldAction);
    textToolBar->addAction(italicAction);
    textToolBar->addAction(underlineAction);

    QToolButton *pointerButton = new QToolButton;
    pointerButton->setCheckable(true);
    pointerButton->setChecked(true);
    pointerButton->setIcon(QIcon(":/images/pointer.png"));
    QToolButton *linePointerButton = new QToolButton;
    linePointerButton->setCheckable(true);
    linePointerButton->setIcon(QIcon(":/images/linepointer.png"));

    pointerTypeGroup = new QButtonGroup(this);
    connect(pointerTypeGroup, SIGNAL(buttonClicked(int)),
            this, SLOT(pointerGroupClicked(int)));

    sceneScaleCombo = new QComboBox;
    QStringList scales;
    scales << tr("50") << tr("75") << tr("100") << tr("125") << tr("150");
    sceneScaleCombo->addItems(scales);
    sceneScaleCombo->setCurrentIndex(2);
    sceneScaleCombo->setEditable(true);
    QIntValidator *scaleValidator = new QIntValidator(1, 200, this);
    sceneScaleCombo->setValidator(scaleValidator);
    connect(sceneScaleCombo, SIGNAL(currentTextChanged(QString)),
            this, SLOT(sceneScaleChanged(QString)));
    QLabel* percentLabel = new QLabel(tr("%"), this);

    pointerToolbar = addToolBar(tr("Курсор"));
    pointerToolbar->addWidget(pointerButton);
    pointerToolbar->addWidget(linePointerButton);
    pointerToolbar->addWidget(sceneScaleCombo);
    pointerToolbar->addWidget(percentLabel);
}

/**
 * Создание Панели элементов:
 *  - Объект
 *  - Текст
 */
void MainWindow::createToolBox()
{
    buttonGroup = new QButtonGroup(this);
    buttonGroup->setExclusive(false);
    connect(buttonGroup, SIGNAL(buttonClicked(int)),
            this, SLOT(buttonGroupClicked(int)));
    QGridLayout *layout = new QGridLayout;

    QToolButton *textButton = new QToolButton;
    textButton->setCheckable(true);
    buttonGroup->addButton(textButton, InsertTextButton);
    textButton->setIcon(QIcon(QPixmap(":/images/textpointer.png")));
    textButton->setIconSize(QSize(50, 50));
    QGridLayout *textLayout = new QGridLayout;
    textLayout->addWidget(textButton, 0, 0, Qt::AlignHCenter);
    textLayout->addWidget(new QLabel(tr("Текст")), 2, 0, Qt::AlignCenter);
    QWidget *textWidget = new QWidget;
    textWidget->setLayout(textLayout);
    layout->addWidget(textWidget, 2, 0);

    layout->setRowStretch(3, 10);
    layout->setColumnStretch(2, 10);
    QWidget *itemWidget = new QWidget;
    itemWidget->setLayout(layout);

    toolBox = new QToolBox;
    toolBox->setSizePolicy(QSizePolicy(QSizePolicy::Maximum, QSizePolicy::Ignored));
    toolBox->setMinimumWidth(itemWidget->sizeHint().width());
    toolBox->addItem(itemWidget, tr("Фигуры"));
}





