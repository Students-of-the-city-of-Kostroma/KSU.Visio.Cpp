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
#include "element.h"

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
<<<<<<< Updated upstream
    void createActions();

    QMenu *fileMenu;
    QMenu *edit;
    QMenu *about;
    QMenu *settings;
=======
    QWidget *createElement(QString &, Element::type);

    QMenu *fileMenu;
    QMenu *editMenu;
    QMenu *aboutMenu;
    QMenu *settingsMenu;
>>>>>>> Stashed changes

    QAction *saveAction;
    QAction *openAction;
    QAction *createAction;
<<<<<<< Updated upstream
    QAction *exitAction;
    QAction *deleteAction;
    QAction *undoAction;
    QAction *cancelUndoAction;
    QAction *aboutAction;
    QAction *settingsAction;
=======
    QAction *cancelAction;
    QAction *revertCancelAction;
    QAction *aboutAction;
    QAction *settingsAction;

    QButtonGroup *buttonGroup;
>>>>>>> Stashed changes
};
#endif // MAINWINDOW_H
