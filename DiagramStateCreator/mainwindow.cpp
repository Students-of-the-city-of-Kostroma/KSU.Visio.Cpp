/****************************************************************************
**
** Copyright (C) 2016 The Qt Company Ltd.
** Contact: https://www.qt.io/licensing/
**
** This file is part of the project Diagram State Creator
**
****************************************************************************/
#include "mainwindow.h"


#include <QtWidgets>
#include <QMenuBar>

MainWindow::MainWindow()
{
    createActions();
    createMenu();

    setWindowTitle(tr("Diagram State Creator"));
    setWindowIcon(QIcon(":/images/logo.png"));
    setUnifiedTitleAndToolBarOnMac(true);    
}


void MainWindow::createMenu()
{
   fileMenu = menuBar()->addMenu(tr("&File"));
   fileMenu ->addAction(createAction);
   fileMenu ->addAction(openAction);
   fileMenu ->addAction(saveAction);
   fileMenu ->addSeparator();
   fileMenu ->addAction(exitAction);

   edit = menuBar()->addMenu(tr("&Edit"));
   edit->addAction(deleteAction);
   edit->addAction(undoAction);
   edit->addAction(cancelUndoAction);

   settings = menuBar()->addMenu(tr("&Settings"));
   settings->addAction(settingsAction);

   about = menuBar()->addMenu(tr("&About"));
   about->addAction(aboutAction);
}

/**
 * Создание действий:
 *      createAction     - создать новую диаграмму
 *      openAction       - открыть диаграмму
 *      saveAction       - сохранить диаграмму
 *      exitAction       - выйти из приложения
 *      deleteAction     - удалить элемент на диаграмме
 *      undoAction       - вернуть изменния обратно
 *      cancelUndoAction - применить отмененные изменения
 *      settingsAction   - открыть натсройки приложения
 *      aboutAction      - информация о приложении (Руководство пользователя)
 *
 * К действиям приклеиваем картинки и сочетания клавиш
 */
void MainWindow::createActions()
{
    createAction = new QAction(QIcon(":/images/createDocument.png"), tr("&Create..."), this);
    createAction->setShortcut(tr("Ctrl+N"));
    createAction->setStatusTip(tr("Create a new document"));
//    connect(createAction, &QAction::triggered, this, &MainWindow::createDocument);

    openAction = new QAction(QIcon(":/images/openDocument.png"), tr("&Open..."), this);
    openAction->setShortcut(tr("Ctrl+O"));
    openAction->setStatusTip(tr("Open already created document"));
//    connect(openAction, &QAction::triggered, this, &MainWindow::openDocument);

    saveAction = new QAction(QIcon(":/images/saveDocument.png"), tr("&Save"), this);
    saveAction->setShortcut(tr("Ctrl+S"));
    saveAction->setStatusTip(tr("Save changes in document"));
//    connect(saveAction, &QAction::triggered, this, &MainWindow::saveDocument);

    exitAction = new QAction(tr("E&xit"), this);
    exitAction->setShortcuts(QKeySequence::Quit);
    exitAction->setStatusTip(tr("Quit App"));
    connect(exitAction, &QAction::triggered, this, &QWidget::close);

    deleteAction = new QAction(QIcon(":/images/delete.png"), tr("&Delete"), this);
    deleteAction->setShortcut(tr("Delete"));
    deleteAction->setStatusTip(tr("Delete item from diagram"));
//    connect(deleteAction, &QAction::triggered, this, &MainWindow::deleteElement);

    undoAction = new QAction(QIcon(":/images/undo.png"), tr("&Undo"), this);
    undoAction->setShortcut(tr("Ctrl+Z"));
//    connect(undoAction, &QAction::triggered, this, &MainWindow::undo);

    cancelUndoAction = new QAction(QIcon(":/images/revertUndo.png"), tr("Revert &Undo"), this);
    cancelUndoAction->setShortcut(tr("Ctrl+Y"));
//    connect(cancelUndoAction, &QAction::triggered, this, &MainWindow::cancelUndo);

    settingsAction = new QAction(QIcon(":/images/settings.png"), tr("&Settings"), this);
//    connect(settingsAction, &QAction::triggered, this, &MainWindow::displaySettings);

    aboutAction = new QAction(QIcon(":/images/about.png"), tr("&About"), this);
    aboutAction->setShortcut(tr("F1"));
    connect(aboutAction, &QAction::triggered, this, &MainWindow::showAbout);
}

void MainWindow::showAbout()
{
    QMessageBox::about(this, tr("About Diagram App"), tr("Something..."));
}
