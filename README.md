## Rozproszone systemy obiektowe - Zadanie 3 (WCF)
### Zadanie to: 
Usługa udostępniająca połączenia lotnicze pomiędzy wskazanymi lotniskami.
Usługa posiada bazę połączeń pomiędzy miastami: lotnisko/port A, godzina odlotu, lotnisko/port B, godzina przylotu;
Baza powinna być wczytywana z pliku csv.
### Zapytanie do usługi:
podając port A, port B, przedział czasowy (opcjonalnie, gdy niepodane to usługa zwraca wszystkie połączenia bezpośrednie i pośrednie, gdy podane to usługa zwraca połączenia bezpośrednie i pośrednie w przedziale czasowym);
Obsługa wyjątków: nieistniejące połącznia (pusta lista), błędny input (walidacja po stronie klienta oraz walidacja po stronie serwera), brak połączenia z serwerem;
### Klient powinien obsłużyć przypadki:
Nieistniejąca miejscowość – wskazanie, która z podanych miejscowości nie istnieje;
Brak połączenia – wskazanie, że pomiędzy podanymi miejscowościami połącznie nie istnieje;
Obsługa połączeń pośrednich – wynajdywanie połączeń wymagających przesiadki, wylistowanie przesiadek.
