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
    void createDocument();
    void openDocument();
    void saveDocument();
    void deleteElement();
    void undo();
    void cancelUndo();
    void displaySettings();
    void showAbout();

private:
    void createMenu();
    void createActions();

    QMenu *fileMenu;
    QMenu *edit;
    QMenu *about;
    QMenu *settings;

    QAction *saveAction;
    QAction *openAction;
    QAction *createAction;
    QAction *exitAction;
    QAction *deleteAction;
    QAction *undoAction;
    QAction *cancelUndoAction;
    QAction *aboutAction;
    QAction *settingsAction;
};
#endif // MAINWINDOW_H
