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
    setWindowTitle(tr("Diagram State Creator"));
    setWindowIcon(QIcon(":/images/logo.png"));
    setUnifiedTitleAndToolBarOnMac(true);    
}
void MainWindow::CreateMenu()
{
   fileMenu = menuBar()->addMenu(tr("&File"));
   fileMenu ->addAction(createAction);
   fileMenu ->addAction(openAction);
   fileMenu ->addAction(saveAction);

   edit = menuBar()->addMenu(tr("&Edit"));
   edit->addAction(cancelAction);
   edit->addAction(revertCancelAction);

   about = menuBar()->addMenu(tr("&About"));
   about->addAction(aboutAction);

   settings = menuBar()->addMenu(tr("&Settings"));
   settings->addAction(settingsAction);
}
