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
##### <sup> Кпримеру  здесь в модуле Notification,класс SendEmailOrderHandler  обращается к классу OrdersContract(реализующий IOrdersContract), который в свою очередь обращается к слою Application, модуля Orders. Application уже обращается к слою Infrastructure, что бы вернуть Id заказ, для класса  SendEmailOrderHandler. </sup>
```с#
  internal class SendEmailOrderHandler : INotificationHandler<SendEmailOrderNotification>
    {
        private readonly IEmailService emailService;
        private readonly IOrdersContract ordersContract;
        public SendEmailOrderHandler(IEmailService emailService, IOrdersContract ordersContract)
        {
            this.emailService = emailService;
            this.ordersContract = ordersContract;
        }

        public async Task Handle(SendEmailOrderNotification notification, CancellationToken cancellationToken)
        {
            var id = await ordersContract.GetIdByOrderAsync(notification.Id);
            await emailService.SendEmailAsync(notification.Email,"Вашь заказ", $"Вашь заказ под номером {id} готов. Можите приехать по адрессу Городской округ Щёлково, база «Байкал» ");

            await Task.CompletedTask;
        }
    }
```

## <sup> Функциональность проекта </sup>
### <sup> 1. Модуль Identity </sup>
+ <sup> Авторизация администратора. </sup>
<sup> Login: Admin; Password: Aa123! </sup>
### <sup> Строка подключения </sup>
```
  "ConnectionStrings": {
    "BodyCarBd": "Host=localhost;Port=5432;Database=BodyCarBd;Username=postgres;Password=123;"
  },
```
### <sup> 2. Модуль Cart </sup>
+ <sup> Добавление продуктов в корзину. </sup>
+ <sup> Удаление продукта из корзины. </sup>
+ <sup> На стороне администратора просмотр корзин. </sup>
### <sup> Строка подключения </sup>
```
 "CartDbSettings": {
    "ProductsCollesctionName": "Cart",
    "CoursesCollectionNmae": "Courses",
    "ConnectionStrings": "mongodb_container:27017",
    "DatabaseName": "CartDb"
  },
```
  
### <sup> 2. Модуль Orders </sup>
+ <sup> Оформление заказа, путём ввода данных пользователем. </sup>
+ <sup> Продукты в заказ передаются из корзины. </sup>
+ <sup> На стороне администратора просмотр и удаление заказов. </sup>

### <sup> 3. Модуль Products </sup>
+ <sup> Создание продукта. </sup>
+ <sup> На стороне администратора просмотр и удаление продуктов. </sup>
### <sup> Строка подключения </sup>
```
  "ProductDbSettings": {
    "ProductsCollesctionName": "Products",
    "CoursesCollectionNmae": "Courses",
    "ConnectionStrings": "mongodb_container:27017",
    "DatabaseName": "ProductDb"
  },
```
### <sup> 4. Модуль Notification </sup>
+ <sup> Отправка письменного оповещения, на почту клиента. </sup>

