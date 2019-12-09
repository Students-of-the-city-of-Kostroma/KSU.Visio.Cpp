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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    void createActions();

    QMenu *fileMenu;
    QMenu *edit;
    QMenu *about;
    QMenu *settings;
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    QWidget *createElement(QString &, Element::type);

    QMenu *fileMenu;
    QMenu *editMenu;
    QMenu *aboutMenu;
    QMenu *settingsMenu;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

    QAction *saveAction;
    QAction *openAction;
    QAction *createAction;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    QAction *exitAction;
    QAction *deleteAction;
    QAction *undoAction;
    QAction *cancelUndoAction;
    QAction *aboutAction;
    QAction *settingsAction;
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    QAction *cancelAction;
    QAction *revertCancelAction;
    QAction *aboutAction;
    QAction *settingsAction;

    QButtonGroup *buttonGroup;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
};
#endif // MAINWINDOW_H
