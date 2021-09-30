
# EGVP-AddressBook
Bei diesem Projekt handelt es sich um eine .NET WPF Anwendung, welche eine Suche nach Postfächern mithilfe des Egvp-Enterprise Webservices (von der Firma Governikus) ermöglicht.

# Development

Um das Projekt aus der Entwicklungsumgebung zu erstellen/starten sind folgende Schritte nowendig
- in src\EgvpAddressbook\ kann die Datei App.Debug.template.config in App.Debug.config und die Datei App.Release.template.config in App.Release.config umbenannt werden. Dort können anschließend die weiteren Einstellungen zur lokalen Serverumgebung hinterlegt werden.
- um den Webservice zu aktualisieren, bspw. bei upgrade auf eine neuere Egvp-Enterprise version, sind folgende Schritte notwendig
  - Rechtsklick auf Connected Service "EgvpEnterpriseSoap" 
  - in dem sich öffnenden Kontextmenü muss als erstes via Menüpunkt "Configure Service Reference" ein entsprechend erreichbarer Egvp-Enterprise Webservice konfiguriert werden (siehe auch auskommentierte Beispiele in der Datei)
  - anschließend kann über den Menüpunkt "Update Service Reference" der Webservice entsprechend aktualisiert werden

# Kontakt

Oberverwaltungsgericht Rheinland-Pfalz, Deinhardpassage 1, 56068 Koblenz 
Telefon: 0261 1307 - 0
poststelle(at)ovg.jm.rlp.de

# Lizenz

Copyright ©2021 Oberverwaltungsgericht Rheinland-Pfalz 
Lizenziert unter der EUPL, version 1.2 oder höher
Für weitere Details siehe Lizenz.txt oder EUPL-1.2 EN.txt
oder online unter https://joinup.ec.europa.eu/collection/eupl/eupl-text-eupl-12