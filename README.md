﻿# Интерактивная история

Приложение представляет собой небольшую игру с элементами выбора и множеством вариантов развития сюжета. Игра имеет основную историю, которая ветвится на множество вариантов, и может привести к разным концовкам.

## Формат игрового сообщения
Игровые сообщения представлены в следующем формате JSON:

```json
{
    "id": "105",
    "title": "Заголовок сообщения, используется как часть в списке выборов",
    "description": "Основной текст сообщения, здесь будет идти кусочек истории",
    "choices": [
      "110",
      "111"
    ]
}
```

Для создания интерактивной истории была использована библиотека NuGet - [Spectre.Console](https://spectreconsole.net/).
