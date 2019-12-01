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

MainWindow::MainWindow()
{
    setWindowTitle(tr("Diagram State Creator"));
    setWindowIcon(QIcon(":/images/logo.png"));
    setUnifiedTitleAndToolBarOnMac(true);
}
