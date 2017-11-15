using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public enum DSA_TALENTS { PHYSICALLY, SOCIAL, NATURE, KNOWLDAGE }

    class ControllTalent
    {

        private Dictionary<DSA_TALENTS, List<Talent>> talente;

        public ControllTalent()
        {
            talente = new Dictionary<DSA_TALENTS, List<Talent>>();

            createPhysicalTalents(DSA_TALENTS.PHYSICALLY);
            createSocialTalents(DSA_TALENTS.SOCIAL);
            createNatureTalents(DSA_TALENTS.NATURE);
            createKnowldageTalents(DSA_TALENTS.KNOWLDAGE);
        }
        private void createPhysicalTalents(DSA_TALENTS type)
        {
            List<Talent> list = new List<Talent>();

            Talent Atlethik             = new Talent("Atlethik",            new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.KO, DSA_ATTRIBUTE.KK },2, "-",                        "Körperbeherschung(+5), Akrobatik");
            Talent Klettern             = new Talent("Klettern",            new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.KK },2, "-",                        "Athletik o. Akrobatik (+5), Körperbeherrschung");
            Talent Körperbeherrschung   = new Talent("Körperbeherrschung",  new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.GE },2, "-",                        "Akrobatik (+5), Athletik");
            Talent Schleichen           = new Talent("Schleichen",          new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.GE },1, "-",                        "Körperbeherrschung, Sich Verstecken");
            Talent Schwimmen            = new Talent("Schwimmen",           new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.KO, DSA_ATTRIBUTE.KK },2, "-",                        "Athletik (+15)");
            Talent Selbstbeherrschung   = new Talent("Selbstbeherrschung",  new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.KO, DSA_ATTRIBUTE.KK },0, "-",                        "-");
            Talent SichVerstecken       = new Talent("SichVerstecken",      new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.GE },2, "-",                        "Schleichen, Körperbeherrschung (+15)");
            Talent Singen               = new Talent("Singen",              new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH, DSA_ATTRIBUTE.CH },3, "-",                        "-");
            Talent Sinnenschärfe        = new Talent("Sinnenschärfe",       new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.IN },0, "-",                        "KL/IN/FF (+-0)");
            Talent Tanzen               = new Talent("Tanzen",              new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.CH, DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.GE },2, "-",                        "Körperbeherrschung (+5), Akrobatik (+5)");
            Talent Zechen               = new Talent("Zechen",              new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.KO, DSA_ATTRIBUTE.KK },0, "-",                        "-");
            Talent Akrobatik            = new Talent("Akrobatik",           new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.KK },2, "Körperbeherrschung 4",     "Körperbeherrschung (+5), Athletik");
            Talent Fliegen              = new Talent("Fliegen",             new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.GE },1, "-",                        "Akrobatik");
            Talent Gaukeleien           = new Talent("Gaukeleien",          new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.CH, DSA_ATTRIBUTE.FF },2, "-",                        "Taschendiebstahl, Falschspiel");
            Talent Reiten               = new Talent("Reiten",              new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.CH, DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.KK },2, "-",                        "Körperbeherrschung, Akrobatik (+15)");
            Talent Skifahren            = new Talent("Skifahren",           new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.KO },2, "-",                        "Athletik, Körperbeherrschung (+15)");
            Talent StimmenImitieren     = new Talent("StimmenImitieren",    new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH },4, "Sinnenschärfe 4",          "Gaukeleien (Bauchreden) (+5)");
            Talent Taschendiebstahl     = new Talent("Taschendiebstahl",    new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.FF },2, "10+: Menschenkenntnis 4",  "Gaukeleien (Taschenspielereien)");

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

            talente.Add(type, list);
        }
        private void createSocialTalents(DSA_TALENTS type)
        {
            List<Talent> list = new List<Talent>();

            Talent Menschenkenntnis         = new Talent("Menschenkentniss",        new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, "-", "Heilkunde Seele (+5)");
            Talent Überreden                = new Talent("Überreden",               new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, "-", "Überzeugen");
            Talent Betören                  = new Talent("Betören",                 new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH, DSA_ATTRIBUTE.CH }, "Menschenkenntnis 4", "Überreden, Überzeugen, Galanterie (+5)");
            Talent Etikette                 = new Talent("Etikette",                new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, "-", "Galanterie");
            Talent Gassenwissen             = new Talent("Gassenwissen",            new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, "-", "Menschenkenntnis");
            Talent Lehren                   = new Talent("Lehren",                  new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, "10+: Menschenkenntnis 4", "Überzeugen");
            Talent Schauspielerei           = new Talent("Schauspielerei",          new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.CH }, "Etikette, Sich Verkleiden, Singen, Überreden, Überzeugen je 4", "Überreden");
            Talent SchriftlicherAusdruck    = new Talent("SchriftlicherAusdruck",   new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.IN }, "Lesen/Schreiben (entsprechende Schrift) 6", "Lesen/Schreiben, Überzeugen (Rhetorik schriftlich) (+5)");
            Talent SichVerkleiden           = new Talent("SichVerkleiden",          new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.CH, DSA_ATTRIBUTE.GE }, "-", "Schauspielerei");
            Talent Überzeugen               = new Talent("Überzeugen",              new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, "Menschenkenntnis 4", "Überreden");

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

            talente.Add(type, list);
        }
        private void createNatureTalents(DSA_TALENTS type)
        {
            List<Talent> list = new List<Talent>();

            Talent Fährtensuchen        = new Talent("Fährtensuchen",       new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.KO }, "-", "Sinnenschärfe");
            Talent Orientierung         = new Talent("Orientierung",        new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.IN }, "-", "Sternkunde");
            Talent Wildnisleben         = new Talent("Wildnisleben",        new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.KO }, "-", "Tierkunde, Pflanzenkunde");
            Talent Fallenstellen        = new Talent("Fallenstellen",       new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.KK }, "10+: Wildnisleben 4", "Wildnisleben");
            Talent FesselnEntfesseln    = new Talent("Fesseln-Entfesseln",  new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.GE, DSA_ATTRIBUTE.KK }, "-", "Seiler, Seefahrt, Entfesseln: Akrobatik (Winden) (+5), Ringen-PA (+10)");
            Talent FischenAngeln        = new Talent("Fischen-Angeln",      new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.FF, DSA_ATTRIBUTE.KK }, "-", "Wildnisleben");
            Talent Wettervorhersage     = new Talent("Wettervorhersage",    new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.IN }, "-", "Wildnisleben");

            list.Add(Fährtensuchen);
            list.Add(Orientierung);
            list.Add(Wildnisleben);
            list.Add(Fallenstellen);
            list.Add(FesselnEntfesseln);
            list.Add(FischenAngeln);
            list.Add(Wettervorhersage);

            talente.Add(type, list);
        }
        private void createKnowldageTalents(DSA_TALENTS type)
        {
            List<Talent> list = new List<Talent>();

            Talent GötterKulte          = new Talent("Götter-Kulte",        new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "-", "Geschichtswissen, Sagen/Legenden");
            Talent Rechnen              = new Talent("Rechnen",             new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "-", "-");
            Talent SagenLegenden        = new Talent("Sagen-Legenden",      new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, "-", "Geschichtswissen, Götter/Kulte");
            Talent Anatomie             = new Talent("Anatomie",            new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF }, "Keine Totenangst", "Heilkunde Wunde (+5), Heilkunde Krankheiten");
            Talent Baukunst             = new Talent("Baukunst",            new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF }, "Lesen/Schreiben 4, Malen/Zeichnen 4, Rechnen 5", "Zimmermann, Maurer, Steinmetz");
            Talent BrettKartenspiel     = new Talent("Brett-Kartenspiel",   new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "-", "Kriegskunst (Strategie), Rechnen");
            Talent Geographie           = new Talent("Geographie",          new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "-", "-");
            Talent Geschichtswissen     = new Talent("Geschichtswissen",    new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "Lesen/Schreiben 4", "Sagen/Legenden (+5 o. +10)");
            Talent Gesteinskunde        = new Talent("Gesteinskunde",       new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.FF }, "-", "Baukunst, Steinschneider, Bergbau, Hüttenkunde, Steinmetz (+5)");
            Talent Heraldik             = new Talent("Heraldik",            new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF }, "-", "Etikette");
            Talent Hüttenkunde          = new Talent("Hüttenkunde",         new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.KO }, "-", "Alchimie, Grobschmied (+15), Metallguss");
            Talent Kriegskunst          = new Talent("Kriegskunst",         new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.CH }, "-", "Brettspiel");
            Talent Kryptographie        = new Talent("Kryptographie",       new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "L/S und Rechnen je 6, Sprachenkunde 4. M/Z 4", "Sprachenkunde, Rechnen");
            Talent Magiekunde           = new Talent("Magiekunde",          new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "10+: Lesen/Schreiben 6", "Sagen/Legenden, Götter/Kulte");
            Talent Mechanik             = new Talent("Mechanik",            new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.FF }, "10+: L/S, M/Z, Rechnen je 6", "Feinmechanik");
            Talent Pflanzenkunde        = new Talent("Pflanzenkunde",       new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.FF }, "-", "Wildnisleben");
            Talent Philosophie          = new Talent("Philosophie",         new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "-", "Götter/Kulte, Magiekunde, Geschichtswissen (+15), Sagen/Legenden (+15)");
            Talent Rechtskunde          = new Talent("Rechtskunde",         new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "-", "Etikette, Staatskunst");
            Talent Schätzen             = new Talent("Schätzen",            new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.IN }, "-", "Handel o. Juwelier o. Feinm. (Goldschmied) (+5), Zimmermann");
            Talent Sprachenkunde        = new Talent("Sprachenkunde",       new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "-", "-");
            Talent Staatskunst          = new Talent("Staatskunst",         new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH }, "-", "Hauswirtschaft, Rechtskunde (Staatsrecht)");
            Talent Sternkunde           = new Talent("Sternkunde",          new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "10+: L/S 6, Rechnen 6, Sinnenschärfe 6", "Gabe Prophezeien (Astrologie) (+5)");
            Talent Tierkunde            = new Talent("Tierkunde",           new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.MU, DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN }, "-", "Viehzucht, Seefischerei, Reiten, Wildnisleben");

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

            talente.Add(type, list);
        }

        public List<Talent> getTalentList(DSA_TALENTS type)
        {
            List<Talent> outList;

            talente.TryGetValue(type, out outList);
            return outList;
        }
    }
}
