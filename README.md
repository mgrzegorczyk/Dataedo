# Code Rewiev
``` csharp
[HttpPost ("delete/{id}")] public void Delete (uint id)
```
- akcję usuwania powinno sie wykonywać dedykowaną metodą HttpDelete zamiast HttpPost

- synchroniczne operacje mogą blokować wątki, co może prowadzić do marnowania zasobów serwera i spadku wydajności, zrobiłbym ten endpoint async

- uint w parametrze jest ok jeżeli stosujemy podejście, że DB zawiera rekordy z ID jako kolejne liczby naturalne i nie szyfrujemy tego w żaden sposób
- warto rozważyć szyfrowanie ID jako krok ku bezpieczeństwu

``` csharp
User user = _context.Users.FirstOrDefault(user => user.Id == id);
```
- context nie powinien być wstrzykiwany bezpośrednio do kontrolera, sugeruję zastosowanie tu CQRS i użycie MediatR do popchnięcia operacji usuwania dalej
- to też powinno być async

``` csharp
_context.Users.Remove(user);
```
- usunie rekord z DB, ale wg. mnie lepszym podejściem byłby soft delete (user posiada np. flagę IsActive, którą zmieniamy na false zamiast usuwać rekord)

``` csharp
Debug.WriteLine($"The user with Login={user.login} has been deleted.");
```
- lepiej użyć gotowego rozwiązania do logowania np. NLog

``` csharp
return Ok();
```
- akcja została wykonana i nie ma potrzeby dostarczania dalszych informacji, dlatego zwróciłbym NoContent() - 204, zamiast Ok() - 200

# Opis poprawionej implementacji
- projekty w solucji są podzielone w stylu Clean Architecture (API, Domain, Infrastructure, Application)
- projektem startowym jest API
- API zawiera UserController który posiada endpointy odpowiedzialne za zwrócenie wszystkich użytkowników oraz usunięcie użytkownika o danym ID
- operacje wykonuję asynchronicznie
- zamiast uint uzyłem Guid dla ID
- używam InMemoryDatabase
- na start aplikacji są seedowane 3 rekordy do tabeli Users
- loguję za pomocą Nlog w konsoli
- stosuję soft delete
- nie używam contextu w kontrolerze, zastosowałem CQRS i korzystam z MediatR
