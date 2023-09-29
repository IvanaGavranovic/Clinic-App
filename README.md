# Clinic
Project from the subject database 2

Tekstualni opis ER konceptualne šeme baze podataka:
1. Klinika ima više departmana, a mora imati najmanje jedan. Departman može
biti u sklopu više klinika, a ne mora biti ni u jednoj.
2. Doktor radi u najviše jednom departmanu u okviru klinike kojoj taj departman
pripada, a ne mora ni u jednom. Na jednom departmanu radi više doktora, a
mora najmanje da radi jedan.
3. Doktor može biti ili doktor opšte prakse ili doktor specijalista.
4. Pacijent može da posjećuje više departmana u okviru klinike kojoj taj
departman pripada, a ne mora nijedan. Svaki departmanu u okviru klinike može
da posjeti više pacijenata, a ne mora nijedan.
5. Svaki pacijent koji posjeti kliniku ima otvoren samo jedan zdravstveni karton u
kom se vodi evidencija o njemu ili ga nema još uvijek. Na svakom
zrdavstvenom kartonu se nalaze informacije o tačno jednom pacijentu date
klinike.
6. Svaki doktor koji radi na klinici potpisuje tačno jedan ugovor sa tom klinikom.
Ugovor je potpisan od strane jednog doktora ili još uvijek nije potpisan.
7. Ugovor može biti stalni ili na određeno vreme
=> dom(VRSTA_UGOVORA)={stalni, na_određeno_vrijeme}.
8. Doktor opšte prakse zakazuje više pregleda, a ne mora nijedan. Pregled je
zakazan od strane tačno jednog doktora opšte prakse.
9. Pacijent dolazi na vise zakazanih pregleda kod doktora opšte prakse, a ne mora
ni na jedan. Na zakazani pregled kod doktora opšte prakse dolazi najviše jedan
pacijent, a ne mora ni jedan.
10. Pacijent koji je došao na zakazani pregled dobija jedan ishod pregleda ili ga ne
dobije odmah. Ishod pregleda se odnosi na tačno jednog pacijenta.
11. Ishod pregleda moze biti ili dijagnoza ili uput doktoru specijalisti.
12. U skladu sa postavljenom dijagnozom propisuje se terapija, a i ne mora
(pacijent je zdrav). Terapija moze da se odnosi na jednu dijagnozu, a moze i na
više.
13. Doktor specijalista može obaviti više dodatnih pregled na osnovu uputa koji je
izdao doktor opšte prakse ili ne obaviti nijedan. Uput se odnosi na jednog ili
više doktora specijalista.
14. Doktor specijalista na osnovu obavljenog dodatnog pregleda postavlja jednu
dijagnozu ili je ne postavi. Dijagnoza može biti postavljena na osnovu jednog ili
više pregleda.
15. Za uspostavljenu dijagnozu specijaliste se može odrediti više terapija, a ne
mora nijedna. Terapija se odnosi na jednu dijaznozu postavljenu od strane
specijaliste, a može i na više dijagnoza.
16. Terapija može biti: lijek, masaža, vježbe, banja.
=> dom(VRSTA_TERAPIJE)={lijek, masaža, vježbe, banja}.
