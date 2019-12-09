/****************************************************************************
**
** Copyright (C) 2016 The Qt Company Ltd.
** Contact: https://www.qt.io/licensing/
**
** This file is part of the project Diagram State Creator
**
****************************************************************************/
#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>

QT_BEGIN_NAMESPACE

QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow();

private slots:

private:
    void createMenu();
    QMenu *fileMenu;
    QMenu *edit;
    QMenu *about;
    QMenu *settings;

    QAction *saveAction;
    QAction *openAction;
    QAction *createAction;
    QAction *cancelAction;
    QAction *revertCancelAction;
    QAction *aboutAction;
    QAction *settingsAction;
};
#endif // MAINWINDOW_H
