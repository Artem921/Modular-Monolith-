## <sup> Проект релизован в качестве демонстрации работы модульного монолита, контейнеров docker. </sup>
#### Стек проекта:
+ <sup> Asp Net Core Web Api </sup>
+ <sup> Docker </sup>
+ <sup> Entity Framework </sup>
+ <sup> MongoDB </sup>
+ <sup> Dapper </sup>
+ <sup> PostgresSQL </sup>
+ <sup> Mapster </sup>
+ <sup> MediatR </sup>

## <sup> Архитектура </sup>
### <sup> Все модули имеют трёхслойную архитектуру. </sup>
+ <sup> .Infrastructure - Здесь вся работа с данными.</sup>
+ <sup> .Application - Здесь Бизнес логика. </sup>
+ <sup> .Controller </sup>


## <sup> Коммуникация </sup>
### <sup> Коммуникация между модулями, происходит за счёт контрактов. </sup>

## <sup> Функциональность проекта </sup>
### <sup> 1. Модуль Identity </sup>
+ <sup> Авторизация администратора. </sup>

<sup> Login: Admin; Password: Aa123! </sup>

### <sup> 2. Модуль Cart </sup>
+ <sup> Добавление продуктов в корзину. </sup>
+ <sup> Удаление продукта из корзины. </sup>
+ <sup> На стороне администратора просмотр корзин. </sup>

'''
 "CartDbSettings": {
    "ProductsCollesctionName": "Cart",
    "CoursesCollectionNmae": "Courses",
    "ConnectionStrings": "mongodb://127.0.0.1:27017",
    "DatabaseName": "CartDb"
  },
  
'''
### <sup> 2. Модуль Orders </sup>
+ <sup> Оформление заказа, путём ввода данных пользователем. </sup>
+ <sup> Продукты в заказ передаются из корзины. </sup>
+ <sup> На стороне администратора просмотр и удаление заказов. </sup>

### <sup> 3. Модуль Products </sup>
+ <sup> Создание продукта. </sup>
+ <sup> На стороне администратора просмотр и удаление продуктов. </sup>

### <sup> 4. Модуль Notification </sup>
+ <sup> Отправка письменного оповещения, на почту клиента. </sup>

