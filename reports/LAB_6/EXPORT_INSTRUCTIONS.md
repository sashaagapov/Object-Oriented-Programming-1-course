# Export Instructions for LAB_6

## 1. Перевірка Markdown preview

Перед експортом відкрийте файл:

- `reports/LAB_6/LAB_6_REPORT.md`

і переконайтеся, що:

- усі відносні шляхи `images/diagrams/...` працюють;
- усі майбутні скріншоти лежать у `images/screenshots/`;
- у preview відображаються обидві class diagrams, activity, sequence, use case та результати виконання програми.

## 2. Експорт PDF через VS Code

Рекомендований ручний шлях:

1. Відкрити `LAB_6_REPORT.md` у VS Code.
2. Запустити `Markdown: Open Preview to the Side`.
3. Перевірити, що всі картинки відображаються.
4. У preview вибрати `Print`.
5. Зберегти як `LAB_6_Report.pdf`.

Цей варіант надійний для локального контролю вигляду сторінок і зображень.

## 3. Експорт PDF через pandoc

Якщо встановлено `pandoc`, можна скористатися такою командою:

```bash
pandoc Object-Oriented-Programming-1-course/reports/LAB_6/LAB_6_REPORT.md \
  -o Object-Oriented-Programming-1-course/reports/LAB_6/LAB_6_Report.pdf
```

Якщо локально виникнуть проблеми зі шрифтами або рендерингом, краще повернутися до експорту через VS Code preview.

## 4. Експорт HTML через pandoc

Для отримання окремої HTML-версії звіту:

```bash
pandoc Object-Oriented-Programming-1-course/reports/LAB_6/LAB_6_REPORT.md \
  -o Object-Oriented-Programming-1-course/reports/LAB_6/LAB_6_Report.html
```

Після експорту перевірте, що HTML лежить поруч із папкою `images/`, інакше картинки не підтягнуться.

## 5. Що здавати в Google Drive

Рекомендований пакет здачі:

- `LAB_6_Report.pdf`
- `reports/LAB_6/LAB_6_REPORT.md`
- `reports/LAB_6/images/`
- опціонально: `reports/LAB_6/doxygen/` або `LAB_6_doxygen_html.zip`

Найбезпечніший практичний варіант:

1. `LAB_6_Report.pdf` як основний файл для перевірки.
2. Архів або папка з `LAB_6_REPORT.md` і `images/` як вихідні матеріали.
3. Doxygen HTML — лише як додаткова технічна документація, якщо вона буде згенерована пізніше.
