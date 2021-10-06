
# EGVP-AddressBook
Bei diesem Projekt handelt es sich um eine .NET WPF Anwendung, welche eine Suche nach Postfächern mithilfe des Egvp-Enterprise Webservices (von der Firma Governikus) ermöglicht.

# Installation und Konfiguration

## Installation
Bei dieser Anwendung handelt es sich um eine .NET Framework Anwendung. Nach dem herunterladen der jeweiligen Version müssen auf Windows-Betriebssystemen keine Abhängigkeiten installiert werden.

## Konfiguration
Nachdem Sie die Software heruntergeladen haben befindet sich im Anwendungsverzeichnis eine Datei "EgvpAddressbook.exe.config". In dieser xml-Datei können Einstellungen vorgenommen werden, um die Anwendung zu konfigurieren. <br>
<br>

### Endpunktadresse

Unterhalb des Knotens "system.serviceModel" Das Binding sowie die Endpunktadresse des Egvp-Enterprise Webservices konfiguriert werden
```
<client>
  <endpoint address="http://[host]:[port]/EGVP-WS/EGVP-WebService"
            binding="basicHttpBinding" bindingConfiguration="EgvpService_EgvpPort"
            contract="EgvpEnterpriseSoap.EgvpPortType" name="EgvpPort"/>
</client>
```

### Anwendungseinstellungen
Unterhalb des Knotens "applicationSettings" folgende Anwendungseinstellungen konfiguriert werden:

|Einstellung|Beschreibung|
|-------------|--------|
|EgvpEnterpriseUserId |Hier muss ein EGVP-Postfach (Id) hinterlegt werden, welches zur Suche genutzt werden kann und im entsprechenden EGVP-Enterprise als Postfach hinterlegt wurde.|
|OsciMailFormat|Per Rechtsklick auf eine Adresse öffnet sich ein Kontextmenü mit den Menüpunkten "Neue OSCI E-Mail erstellen" und "OSCI E-Mail Adresse in den Zwischenspeicher kopieren". Hier kann ein Format inkl. Platzhalter "[EGVP-ID]" hinterlegt werden. Bspw. "egvp_[EGVP-ID]@poststelle.rlp.de" |
|UpdateLink|Hier kann eine Link-Adresse hinterlegt werden, wo neue Versionen der Anwendung verfügbar sind. Dargestellt wird der Link via Klick auf |
|UpdateLinkDescription|Hier kann analog zu der Einstellung "UpdateLink" ein Link-Text hinterlegt werden, welcher statt der Link-Dadresse angezeigt wird.|

<br>

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