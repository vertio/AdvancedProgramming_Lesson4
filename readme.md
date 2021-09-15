# Wyższa Szkoła Bankowa Advanced Programming - labor 4 Krzysztof Drzewiecki 114939 gr23_inf_nw4

W tym laboratorium poruszane są następujące zagadnienia:
1. Technologia 'Razor Pages' nazywana inaczej 'Asp.Net Core Web Apps'.
2. Logowanie do systemu i rejestracja użytkowników.
3. Wykorzystywanie technologii SignalR do wysyłania asynchronicznych wiadomości od serwera do aplikacji klienckich napisanych w JavaScript.

# Zadania do wykonania

1. Dodać zapisywanie komunikatów wysyłanych do serwera do bazy danych. W tym celu utworzyć tabelkę 'Messages' i dodać ją jako część migracji bazy danych w górę (patrz laboratorium 2).
2. Zapisane komunikaty w tabeli Messages wyświetlać na osobnej zakładce 'History'. Zakładka ta ma wyświetlać tylko komunikaty wysłane przez zalogowanego użytkownika.
3. Dodać zakładkę 'Users', która będzie wyświetlać listę zarejestrowanych użytkowników. Zakładka ta ma być widoczna tylko dla użytkownika 'admin@email.com'.

# Wskazówki

1. Pracę można wykonać w grupie
2. Aby dodać zapis do bazy danych należy obsłużyć metodę SendMessage() w klasie ChatHub w pliku ChatHub.cs. 

a) dodać klasę ChatMessage z dwoma polami User, Message i odpowiednio skonfigurować plik config.json
```
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "MvcContext": "Server=(localdb)\\mssqllocaldb;Database=MvcContext;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
```
b) Dodać wstrzykiwanie zaleźności tak jak to miało w kontrolerze MoviesControler w laboratorium 2:

Przykład wstrzykiwania zależności:
```
private readonly MvcContext _context;

public ChatHub(MvcContext context)
{
    ChatMessage message = new ChatMessage(
    _context = context;
}

public async Task SendMessage(string user, string message)
{
    var chatMessage = new ChatMessage(user, message);
	_context.Add(chatMessage);
    await _context.SaveChangesAsync();
    await Clients.All.SendAsync("ReceiveMessage", user, message);
}

```


