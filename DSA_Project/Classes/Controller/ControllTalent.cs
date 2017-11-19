using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public enum DSA_TALENTS { PHYSICALLY, SOCIAL, NATURE, KNOWLDAGE, CRAFTING, CRAFTING1, WEAPONLESS }

    class ControllTalent
    {

        private Dictionary<DSA_TALENTS, List<InterfaceTalent>> talente;

        public ControllTalent()
        {
            talente = new Dictionary<DSA_TALENTS, List<InterfaceTalent>>();

            createPhysicalTalents();
            createSocialTalents();
            createNatureTalents();
            createKnowldageTalents();
            createCraftingTalents();
            createCrafting1Talents();
            createFightWeapenlessalents();
        }
        private void createPhysicalTalents()
        {
            List<InterfaceTalent> list = new List<InterfaceTalent>();

            GeneralTalent Atlethik             = new GeneralTalent("Atlethik",            new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.KO, DSA_ATTRIBUTE.KK },"2", "-",                        "Körperbeherschung(+5), Akrobatik");
            GeneralTalent Klettern             = new GeneralTalent("Klettern",            new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.KK },"2", "-",                        "Athletik o. Akrobatik (+5), Körperbeherrschung");
            GeneralTalent Körperbeherrschung   = new GeneralTalent("Körperbeherrschung",  new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.GE },"2", "-",                        "Akrobatik (+5), Athletik");
            GeneralTalent Schleichen           = new GeneralTalent("Schleichen",          new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.GE },"1", "-",                        "Körperbeherrschung, Sich Verstecken");
            GeneralTalent Schwimmen            = new GeneralTalent("Schwimmen",           new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.KO, DSA_ATTRIBUTE.KK },"2", "-",                        "Athletik (+15)");
            GeneralTalent Selbstbeherrschung   = new GeneralTalent("Selbstbeherrschung",  new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.KO, DSA_ATTRIBUTE.KK },"0", "-",                        "-");
            GeneralTalent SichVerstecken       = new GeneralTalent("SichVerstecken",      new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.GE },"2", "-",                        "Schleichen, Körperbeherrschung (+15)");
            GeneralTalent Singen               = new GeneralTalent("Singen",              new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH, DSA_ATTRIBUTE.CH },"3", "-",                        "-");
            GeneralTalent Sinnenschärfe        = new GeneralTalent("Sinnenschärfe",       new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.IN },"0", "-",                        "KL/IN/FF (+-0)");
            GeneralTalent Tanzen               = new GeneralTalent("Tanzen",              new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.CH, DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.GE },"2", "-",                        "Körperbeherrschung (+5), Akrobatik (+5)");
            GeneralTalent Zechen               = new GeneralTalent("Zechen",              new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.KO, DSA_ATTRIBUTE.KK },"0", "-",                        "-");
            GeneralTalent Akrobatik            = new GeneralTalent("Akrobatik",           new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.KK },"2", "Körperbeherrschung 4",     "Körperbeherrschung (+5), Athletik");
            GeneralTalent Fliegen              = new GeneralTalent("Fliegen",             new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.GE },"1", "-",                        "Akrobatik");
            GeneralTalent Gaukeleien           = new GeneralTalent("Gaukeleien",          new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.CH, DSA_ATTRIBUTE.FF },"2", "-",                        "Taschendiebstahl, Falschspiel");
            GeneralTalent Reiten               = new GeneralTalent("Reiten",              new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.CH, DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.KK },"2", "-",                        "Körperbeherrschung, Akrobatik (+15)");
            GeneralTalent Skifahren            = new GeneralTalent("Skifahren",           new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.KO },"2", "-",                        "Athletik, Körperbeherrschung (+15)");
            GeneralTalent StimmenImitieren     = new GeneralTalent("StimmenImitieren",    new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH },"4", "Sinnenschärfe 4",          "Gaukeleien (Bauchreden) (+5)");
            GeneralTalent Taschendiebstahl     = new GeneralTalent("Taschendiebstahl",    new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.FF },"2", "10+: Menschenkenntnis 4",  "Gaukeleien (Taschenspielereien)");

            list.Add(Atlethik);
            list.Add(Klettern);
            list.Add(Körperbeherrschung);
            list.Add(Schleichen);
            list.Add(Schwimmen);
            list.Add(Selbstbeherrschung);
            list.Add(SichVerstecken);
            list.Add(Singen);
            list.Add(Sinnenschärfe);
            list.Add(Tanzen);
            list.Add(Zechen);
            list.Add(Akrobatik);
            list.Add(Fliegen);
            list.Add(Gaukeleien);
            list.Add(Reiten);
            list.Add(Skifahren);
            list.Add(StimmenImitieren);
            list.Add(Taschendiebstahl);
            
            talente.Add(DSA_TALENTS.PHYSICALLY, list);

            Console.WriteLine("Physical: " + list.Count);
        }
        private void createSocialTalents()
        {
            List<InterfaceTalent> list = new List<InterfaceTalent>();

            GeneralTalent Menschenkenntnis         = new GeneralTalent("Menschenkentniss",        new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, "-", "Heilkunde Seele (+5)");
            GeneralTalent Überreden                = new GeneralTalent("Überreden",               new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, "-", "Überzeugen");
            GeneralTalent Betören                  = new GeneralTalent("Betören",                 new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH, DSA_ATTRIBUTE.CH }, "Menschenkenntnis 4", "Überreden, Überzeugen, Galanterie (+5)");
            GeneralTalent Etikette                 = new GeneralTalent("Etikette",                new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, "-", "Galanterie");
            GeneralTalent Gassenwissen             = new GeneralTalent("Gassenwissen",            new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, "-", "Menschenkenntnis");
            GeneralTalent Lehren                   = new GeneralTalent("Lehren",                  new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, "10+: Menschenkenntnis 4", "Überzeugen");
            GeneralTalent Schauspielerei           = new GeneralTalent("Schauspielerei",          new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.CH }, "Etikette, Sich Verkleiden, Singen, Überreden, Überzeugen je 4", "Überreden");
            GeneralTalent SchriftlicherAusdruck    = new GeneralTalent("SchriftlicherAusdruck",   new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.IN }, "Lesen/Schreiben (entsprechende Schrift) 6", "Lesen/Schreiben, Überzeugen (Rhetorik schriftlich) (+5)");
            GeneralTalent SichVerkleiden           = new GeneralTalent("SichVerkleiden",          new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.CH, DSA_ATTRIBUTE.GE }, "-", "Schauspielerei");
            GeneralTalent Überzeugen               = new GeneralTalent("Überzeugen",              new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, "Menschenkenntnis 4", "Überreden");

            list.Add(Menschenkenntnis);
            list.Add(Überreden);
            list.Add(Betören);
            list.Add(Etikette);
            list.Add(Gassenwissen);
            list.Add(Lehren);
            list.Add(Schauspielerei);
            list.Add(SchriftlicherAusdruck);
            list.Add(SichVerkleiden);
            list.Add(Überzeugen);

            talente.Add(DSA_TALENTS.SOCIAL, list);

            Console.WriteLine("Social: " + list.Count);
        }
        private void createNatureTalents()
        {
            List<InterfaceTalent> list = new List<InterfaceTalent>();

            GeneralTalent Fährtensuchen        = new GeneralTalent("Fährtensuchen",       new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.KO }, "-", "Sinnenschärfe");
            GeneralTalent Orientierung         = new GeneralTalent("Orientierung",        new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.IN }, "-", "Sternkunde");
            GeneralTalent Wildnisleben         = new GeneralTalent("Wildnisleben",        new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.KO }, "-", "Tierkunde, Pflanzenkunde");
            GeneralTalent Fallenstellen        = new GeneralTalent("Fallenstellen",       new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.KK }, "10+: Wildnisleben 4", "Wildnisleben");
            GeneralTalent FesselnEntfesseln    = new GeneralTalent("Fesseln-Entfesseln",  new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.KK }, "-", "Seiler, Seefahrt, Entfesseln: Akrobatik (Winden) (+5), Ringen-PA (+10)");
            GeneralTalent FischenAngeln        = new GeneralTalent("Fischen-Angeln",      new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.KK }, "-", "Wildnisleben");
            GeneralTalent Wettervorhersage     = new GeneralTalent("Wettervorhersage",    new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.IN }, "-", "Wildnisleben");

            list.Add(Fährtensuchen);
            list.Add(Orientierung);
            list.Add(Wildnisleben);
            list.Add(Fallenstellen);
            list.Add(FesselnEntfesseln);
            list.Add(FischenAngeln);
            list.Add(Wettervorhersage);

            talente.Add(DSA_TALENTS.NATURE, list);

            Console.WriteLine("Nature: " + list.Count);
        }
        private void createKnowldageTalents()
        {
            List<InterfaceTalent> list = new List<InterfaceTalent>();

            GeneralTalent GötterKulte          = new GeneralTalent("Götter-Kulte",        new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "-", "Geschichtswissen, Sagen/Legenden");
            GeneralTalent Rechnen              = new GeneralTalent("Rechnen",             new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "-", "-");
            GeneralTalent SagenLegenden        = new GeneralTalent("Sagen-Legenden",      new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, "-", "Geschichtswissen, Götter/Kulte");
            GeneralTalent Anatomie             = new GeneralTalent("Anatomie",            new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF }, "Keine Totenangst", "Heilkunde Wunde (+5), Heilkunde Krankheiten");
            GeneralTalent Baukunst             = new GeneralTalent("Baukunst",            new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF }, "Lesen/Schreiben 4, Malen/Zeichnen 4, Rechnen 5", "Zimmermann, Maurer, Steinmetz");
            GeneralTalent BrettKartenspiel     = new GeneralTalent("Brett-Kartenspiel",   new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "-", "Kriegskunst (Strategie), Rechnen");
            GeneralTalent Geographie           = new GeneralTalent("Geographie",          new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "-", "-");
            GeneralTalent Geschichtswissen     = new GeneralTalent("Geschichtswissen",    new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "Lesen/Schreiben 4", "Sagen/Legenden (+5 o. +10)");
            GeneralTalent Gesteinskunde        = new GeneralTalent("Gesteinskunde",       new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.FF }, "-", "Baukunst, Steinschneider, Bergbau, Hüttenkunde, Steinmetz (+5)");
            GeneralTalent Heraldik             = new GeneralTalent("Heraldik",            new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF }, "-", "Etikette");
            GeneralTalent Hüttenkunde          = new GeneralTalent("Hüttenkunde",         new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.KO }, "-", "Alchimie, Grobschmied (+15), Metallguss");
            GeneralTalent Kriegskunst          = new GeneralTalent("Kriegskunst",         new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.CH }, "-", "Brettspiel");
            GeneralTalent Kryptographie        = new GeneralTalent("Kryptographie",       new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "L/S und Rechnen je 6, Sprachenkunde 4. M/Z 4", "Sprachenkunde, Rechnen");
            GeneralTalent Magiekunde           = new GeneralTalent("Magierkunde",         new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "10+: Lesen/Schreiben 6", "Sagen/Legenden, Götter/Kulte");
            GeneralTalent Mechanik             = new GeneralTalent("Mechanik",            new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF }, "10+: L/S, M/Z, Rechnen je 6", "Feinmechanik");
            GeneralTalent Pflanzenkunde        = new GeneralTalent("Pflanzenkunde",       new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.FF }, "-", "Wildnisleben");
            GeneralTalent Philosophie          = new GeneralTalent("Philosophie",         new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "-", "Götter/Kulte, Magiekunde, Geschichtswissen (+15), Sagen/Legenden (+15)");
            GeneralTalent Rechtskunde          = new GeneralTalent("Rechtskunde",         new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "-", "Etikette, Staatskunst");
            GeneralTalent Schätzen             = new GeneralTalent("Schätzen",            new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.IN }, "-", "Handel o. Juwelier o. Feinm. (Goldschmied) (+5), Zimmermann");
            GeneralTalent Sprachenkunde        = new GeneralTalent("Sprachenkunde",       new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "-", "-");
            GeneralTalent Staatskunst          = new GeneralTalent("Staatskunst",         new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, "-", "Hauswirtschaft, Rechtskunde (Staatsrecht)");
            GeneralTalent Sternkunde           = new GeneralTalent("Sternkunde",          new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "10+: L/S 6, Rechnen 6, Sinnenschärfe 6", "Gabe Prophezeien (Astrologie) (+5)");
            GeneralTalent Tierkunde            = new GeneralTalent("Tierkunde",           new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "-", "Viehzucht, Seefischerei, Reiten, Wildnisleben");

            list.Add(GötterKulte);
            list.Add(Rechnen);
            list.Add(SagenLegenden);
            list.Add(Anatomie);
            list.Add(Baukunst);
            list.Add(BrettKartenspiel);
            list.Add(Geographie);
            list.Add(Geschichtswissen);
            list.Add(Gesteinskunde);
            list.Add(Heraldik);
            list.Add(Hüttenkunde);
            list.Add(Kriegskunst);
            list.Add(Kryptographie);
            list.Add(Magiekunde);
            list.Add(Mechanik);
            list.Add(Pflanzenkunde);
            list.Add(Philosophie);
            list.Add(Rechtskunde);
            list.Add(Schätzen);
            list.Add(Sprachenkunde);
            list.Add(Staatskunst);
            list.Add(Sternkunde);
            list.Add(Tierkunde);

            talente.Add(DSA_TALENTS.KNOWLDAGE, list);

            Console.WriteLine("Knwoldage: " + list.Count);
        }
        private void createCraftingTalents()
        {
            List<InterfaceTalent> list = new List<InterfaceTalent>();

            GeneralTalent HeilkundeWunden          = new GeneralTalent("HeilkundeWunden",         new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.CH, DSA_ATTRIBUTE.FF }, "-", "Anatomie");
            GeneralTalent Holzbearbeitung          = new GeneralTalent("Holzbearbeitung",         new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.KK }, "-", "Zimmermann (+5)");
            GeneralTalent Kochen                   = new GeneralTalent("Kochen",                  new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.FF }, "-", "Fleischer, Fischen/Angeln, Wildnisleben, Alchimie");
            GeneralTalent Lederarbeiten            = new GeneralTalent("Lederarbeiten",           new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.FF }, "-", "Gerber/Kürschner, Schneidern");
            GeneralTalent MalenZeichnen            = new GeneralTalent("MalenZeichnen",           new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.FF }, "-", "Kartographie, Steinmetz (Bildhauer), Tätowieren (+5)");
            GeneralTalent Schneidern               = new GeneralTalent("Schneidern",              new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.FF }, "-", "Webkunst, Lederarbeiten");
            GeneralTalent Abrichten                = new GeneralTalent("Abrichten",               new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, "10+: Tierkunde 4", "Viehzucht, Tierkunde, Reiten");
            GeneralTalent Ackerbau                 = new GeneralTalent("Ackerbau",                new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.KO }, "-", "Viehzucht, Pflanzenkunde");
            GeneralTalent Alchimie                 = new GeneralTalent("Alchimie",                new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF }, "Lesen/Schreiben, Rechnen je 4", "Kochen (Tränke), Pflanzenkunde");
            GeneralTalent Bergbau                  = new GeneralTalent("Bergbau",                 new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.KO, DSA_ATTRIBUTE.KK }, "10+: Gesteinskunde 4", "Steinmetz, Maurer, Baukunst, Gesteinskunde");
            GeneralTalent Bogenbau                 = new GeneralTalent("Bogenbau",                new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.FF }, "Holzbearbeitung 4", "Holzbearbeitung, Feinmechanik, Grobschmied (+15)");
            GeneralTalent BooteFahren              = new GeneralTalent("BooteFahren",             new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.KO, DSA_ATTRIBUTE.KK }, "-", "Seefahrt (+5)");
            GeneralTalent Brauer                   = new GeneralTalent("Brauer",                  new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.KK }, "-", "Alchimie");
            GeneralTalent Drucker                  = new GeneralTalent("Drucker",                 new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.KK }, "Lesen/Schreiben 6, Mechanik, Malen/Zeichnen je 4", "Mechanik");
            GeneralTalent FahrzeugLenken           = new GeneralTalent("FahrzeugLenken",          new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH, DSA_ATTRIBUTE.FF }, "-", "Hundeschlitten Fahren");
            GeneralTalent Falschspiel              = new GeneralTalent("Falschspiel",             new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.CH, DSA_ATTRIBUTE.FF }, "-", "Menschenkenntnis 4, Gaukeleien (Taschenspielereien)");
            GeneralTalent Feinmechanik             = new GeneralTalent("Feinmechanik",            new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.FF }, "Malen/Zeichnen 4", "-");
            GeneralTalent Feuersteinbearbeitung    = new GeneralTalent("Feuersteinbearbeitung",   new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.FF }, "-", "Steinmetz");
            GeneralTalent Fleischer                = new GeneralTalent("Fleischer",               new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.KK }, "-", "Viehzucht, Fischen/Angeln, Tierkunde, Kochen, Anatomie, Gerber / Kürschner(Trophäen)");
            GeneralTalent GerberKürschner          = new GeneralTalent("GerberKürschner",         new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.KO }, "-", "Alchimie, Fleischer");
            GeneralTalent Glaskunst                = new GeneralTalent("Glaskunst",               new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.KO }, "-", "Juwelier");
            GeneralTalent Grobschmied              = new GeneralTalent("Grobschmied",             new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.KK, DSA_ATTRIBUTE.KK }, "-", "Metallguss (+15)");
            GeneralTalent Handel                   = new GeneralTalent("Handel",                  new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, "Rechnen 4", "Hauswirtschaft, Geographie (+15), Schätzen (+15)");
            GeneralTalent Hauswirtschaft           = new GeneralTalent("Hauswirtschaft",          new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH, DSA_ATTRIBUTE.FF }, "-", "Rechnen (Buchführung), Galanterie (Festegestaltung) (+15)");
            GeneralTalent HeilkundeGift            = new GeneralTalent("Heilkunde Gift",          new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "-", "Alchimie (Gifte) (+5), HK Krankheiten, Kochen (Tränke)");
            GeneralTalent HeilkundeKrankheiten     = new GeneralTalent("Heilkunde Krankheiten",   new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.CH }, "-", "Heilkunde Gift");
            GeneralTalent HeilkundeSeele           = new GeneralTalent("Heilkunde Seele",         new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH, DSA_ATTRIBUTE.CH }, "-", "Menschenkenntnis, Überzeugen");
            GeneralTalent Instrumentenbauer        = new GeneralTalent("Instrumentenbauer",       new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.FF }, "Holzbearbeitung, Feinmechanik, Musizieren je 4", "Holzbearbeitung, Feinmechanik");
            GeneralTalent Kartographie             = new GeneralTalent("Kartographie",            new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF }, "Malen/Zeichnen 4", "Orientierung, Sternenkunde");
            GeneralTalent Kristallzucht            = new GeneralTalent("Kristallzucht",           new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.FF }, "-", "Alchimie (+15)");
            
            list.Add(HeilkundeWunden);
            list.Add(Holzbearbeitung);
            list.Add(Kochen);
            list.Add(Lederarbeiten);
            list.Add(MalenZeichnen);
            list.Add(Schneidern);
            list.Add(Abrichten);
            list.Add(Ackerbau);
            list.Add(Alchimie);
            list.Add(Bergbau);
            list.Add(Bogenbau);
            list.Add(BooteFahren);
            list.Add(Brauer);
            list.Add(Drucker);
            list.Add(FahrzeugLenken);
            list.Add(Falschspiel);
            list.Add(Feinmechanik);
            list.Add(Feuersteinbearbeitung);
            list.Add(Fleischer);
            list.Add(GerberKürschner);
            list.Add(Glaskunst);
            list.Add(Grobschmied);
            list.Add(Handel);
            list.Add(Hauswirtschaft);
            list.Add(HeilkundeGift);
            list.Add(HeilkundeKrankheiten);
            list.Add(HeilkundeSeele);
            list.Add(Instrumentenbauer);
            list.Add(Kartographie);
            list.Add(Kristallzucht);

            talente.Add(DSA_TALENTS.CRAFTING, list);

            Console.WriteLine("Crafting: " + list.Count);
        }
        public void createCrafting1Talents()
        {
            List<InterfaceTalent> list = new List<InterfaceTalent>();

            GeneralTalent Maurer = new GeneralTalent("Maurer", new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.KK }, "-", "Baukunst");
            GeneralTalent Metallguss = new GeneralTalent("Metallguss", new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.KK }, "Hüttenkunde 4", "Hüttenkunde, Grobschmied");
            GeneralTalent Musizieren = new GeneralTalent("Musizieren", new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH, DSA_ATTRIBUTE.FF }, "-", "-");
            GeneralTalent SchlösserKnacken = new GeneralTalent("Schlösser Knacken", new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.FF }, "-", "Feinmechanik (+5)");
            GeneralTalent SchnapsBrennen = new GeneralTalent("Schnaps Brennen", new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.FF }, "-", "Alchimie (+5), Brauer, Winzer");
            GeneralTalent Seefahrt = new GeneralTalent("Seefahrt", new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.KK }, "-", "Boote Fahren, Steuermann");
            GeneralTalent Seiler = new GeneralTalent("Seiler", new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.KK }, "-", "Fesseln (Taue spleißen)");
            GeneralTalent Steinmetz = new GeneralTalent("Steinmetz", new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.KK }, "Gesteinskunde 4", "Baukunst, Maurer, Bergbau");
            GeneralTalent SteinschneiderJuwelier = new GeneralTalent("SteinschneiderJuwelier", new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.FF }, "10+: Gesteinskunde 4", "Feinmechanik, Kristallzüchter");
            GeneralTalent Stellmacher = new GeneralTalent("Stellmacher", new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.KK }, "Holzbearbeitung, Lederarbeiten, Grobschmied je 4", "Zimmermann, Schiffbau");
            GeneralTalent StoffeFärben = new GeneralTalent("Stoffe Färben", new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.KK }, "-", "Alchimie, eventuell Drucker für Stoffdruck");
            GeneralTalent Tätowieren = new GeneralTalent("Tätowieren", new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.FF }, "Malen/Zeichnen 4", "Malen/Zeichnen");
            GeneralTalent Töpfern = new GeneralTalent("Töpfern", new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.FF }, "-", "Maurer, Steinmetz");
            GeneralTalent Viehzucht = new GeneralTalent("Viehzucht", new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.KK }, "-", "Tierkunde");
            GeneralTalent Webkunst = new GeneralTalent("Webkunst", new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.KK }, "-", "Schneidern");
            GeneralTalent Winzer = new GeneralTalent("Winzer", new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.KK }, "-", "-");
            GeneralTalent Zimmermann = new GeneralTalent("Zimmermann", new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.KK }, "10+: Holzbearbeitung 4", "Holzbearbeitung, Schiffbau");

            list.Add(Maurer);
            list.Add(Metallguss);
            list.Add(Musizieren);
            list.Add(SchlösserKnacken);
            list.Add(SchnapsBrennen);
            list.Add(Seefahrt);
            list.Add(Seiler);
            list.Add(Steinmetz);
            list.Add(SteinschneiderJuwelier);
            list.Add(Stellmacher);
            list.Add(StoffeFärben);
            list.Add(Tätowieren);
            list.Add(Töpfern);
            list.Add(Viehzucht);
            list.Add(Webkunst);
            list.Add(Winzer);
            list.Add(Zimmermann);

            talente.Add(DSA_TALENTS.CRAFTING1, list);

            Console.WriteLine("Crafting1: " + list.Count);
        }
        public void createFightWeapenlessalents()
        {
            List<InterfaceTalent> list = new List<InterfaceTalent>();

            FightTalent Raufen = new FightTalent("Raufen", "BE", "", DSA_ADVANCEDVALUES.ATTACKE_BASIS, DSA_ADVANCEDVALUES.PARADE_BASIS);
            FightTalent Ringen = new FightTalent("Ringen ", "BE", "", DSA_ADVANCEDVALUES.ATTACKE_BASIS, DSA_ADVANCEDVALUES.PARADE_BASIS);

            list.Add(Raufen);
            list.Add(Ringen);

            talente.Add(DSA_TALENTS.WEAPONLESS, list);
            Console.WriteLine("Weaponless: " + list.Count);
        }
        public List<InterfaceTalent> getTalentList(DSA_TALENTS type)
        {
            List<InterfaceTalent> outList;

            talente.TryGetValue(type, out outList);
            return outList;
        }
    }
}
