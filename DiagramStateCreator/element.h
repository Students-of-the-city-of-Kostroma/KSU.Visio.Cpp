/****************************************************************************
**
** Copyright (C) 2016 The Qt Company Ltd.
** Contact: https://www.qt.io/licensing/
**
** This file is part of the project Diagram State Creator
**
****************************************************************************/
#ifndef ELEMENT_H
#define ELEMENT_H

#include <QtWidgets>

class Element : public QGraphicsPolygonItem
{
public:
    enum type {};

    Element(type, QGraphicsItem *parent = nullptr);
};

#endif // ELEMENT_H
