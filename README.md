# MySchool
Примерен проект на училищен сайт, HTML-а на който в голяма степен се генерира динамично и изработен с помощта на платформана ASP.NET MVC на Microsoft.
Приложението е свързано с база данни, намираща се на SQL сървър, в която се съхранява цялата информация.
Базата данни се създава с помощта на Entity Framework/Code First
Програмният език, който се използва е C#. Използвани са JavaScript и jQuery.
За оформлението на дизайна основно се ползва Bootstrap, като само малка част е направена с "чист" CSS, като целта е да се спазва семантиката на HTML5.

Предвидени са следните възможности:
  1. Нерегистрираните потребители виждат само основното меню. (screenshots/01.PNG)
  2. Администраторът на сайта може да задава роли на регистрираните потребители. (screenshots/06.PNG)
  3. Регистриран потребител, на който е зададена роля "Оператор" може да добавя, редактира или трие съдържание. За местата, където има да се вкарва голямо количество текст и се изисква форматирането му, е предвидено да се използва текстов редактор. (screenshots/07.PNG)
  4. В страницата "Контакти" е вградена геолокация. (screenshots/05.PNG)
