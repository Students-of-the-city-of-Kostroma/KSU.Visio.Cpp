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
    void createActions();
	QWidget* createElement(QString&, Element::type);

    QMenu *fileMenu;
	QMenu *editMenu;
	QMenu *aboutMenu;
	QMenu *settingsMenu;

    QAction *saveAction;
    QAction *openAction;
    QAction *createAction;
    QAction *exitAction;
    QAction *deleteAction;
    QAction *undoAction;
    QAction *cancelUndoAction;
	QAction *settingsAction;
    QAction *aboutAction;

    QButtonGroup *buttonGroup;
};
#endif // MAINWINDOW_H
