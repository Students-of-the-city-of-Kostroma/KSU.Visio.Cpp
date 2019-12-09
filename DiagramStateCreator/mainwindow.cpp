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

   editMenu = menuBar()->addMenu(tr("&Edit"));
   editMenu->addAction(cancelAction);
   editMenu->addAction(revertCancelAction);

   aboutMenu = menuBar()->addMenu(tr("&About"));
   aboutMenu->addAction(aboutAction);

   settingsMenu = menuBar()->addMenu(tr("&Settings"));
   settingsMenu->addAction(settingsAction);
}
