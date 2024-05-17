```mermaid
---
title: PlayerManagerMVC
author: Alexandre Almeida
format: pdf
---
classDiagram
    Player <|-- Program
    Model <|-- Program
    ConsoleView <|-- Program
    CompareByName <|-- Player : implements
    Controller <|-- Model : implements
```