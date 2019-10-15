using System;
using System.Collections.Generic;
using System.Globalization;

namespace BisiparişÇekirdek.Valıklar.Muhasebe
{
    /// <summary>
    /// Represents a system of money within which <see cref="Money"/>
    /// amounts can be compared and arithmetic can be performed.
    /// </summary>
    public class Döviz : IEquatable<Döviz>, IFormatProvider
    {
        public struct DövizTableEntry : IEquatable<DövizTableEntry>
        {
            public readonly String Name;
            public readonly String ArabicName;
            public readonly String Iso3LetterCode;
            public readonly String ArabicLetterCode;
            public readonly UInt16 IsoNumberCode;
            public readonly String Subunit;
            public readonly String Symbol;

            internal DövizTableEntry(String name,
                                      String iso3LetterCode,
                                      UInt16 isoNumberCode,
                                      String subunit,
                                      String symbol)
                : this(name, "", iso3LetterCode, "", isoNumberCode, subunit, symbol)
            {
            }

            internal DövizTableEntry(String name,
                                       string arabicName,
                                      String iso3LetterCode,
                                      string arabicLetterCode,
                                      UInt16 isoNumberCode,
                                      String subunit,
                                      String symbol)
            {
                Name = name; ArabicName = arabicName;
                Iso3LetterCode = iso3LetterCode; ArabicLetterCode = arabicLetterCode;
                IsoNumberCode = isoNumberCode;
                Subunit = subunit;
                Symbol = symbol;
            }

            #region IEquatable<DövizTableEntry> Members

            public Boolean Equals(DövizTableEntry other)
            {
                return IsoNumberCode == other.IsoNumberCode;
            }

            #endregion
        }

        private static readonly Dictionary<Int32, DövizTableEntry> _dövizler
            = new Dictionary<Int32, DövizTableEntry>();

        private static readonly Dictionary<String, Int32> _codeIndex
            = new Dictionary<String, Int32>(StringComparer.InvariantCultureIgnoreCase);

        private static readonly Dictionary<Int32, Int32> _cultureIdLookup
            = new Dictionary<Int32, Int32>();

        public Dictionary<DateTime, decimal> TodaysRates { get; private set; }

        #region Declare currencies
        /// <summary>
        /// Lek
        /// </summary>
        public static readonly Döviz All;

        /// <summary>
        /// Algerian Dinar
        /// </summary>
        public static readonly Döviz Dzd;

        /// <summary>
        /// Argentine Peso
        /// </summary>
        public static readonly Döviz Ars;

        /// <summary>
        /// Australian Dollar
        /// </summary>
        public static readonly Döviz Aud;

        /// <summary>
        /// Bahamian Dollar
        /// </summary>
        public static readonly Döviz Bsd;

        /// <summary>
        /// Bahraini Dinar
        /// </summary>
        public static readonly Döviz Bhd;

        /// <summary>
        /// Taka
        /// </summary>
        public static readonly Döviz Bdt;

        /// <summary>
        /// Armenian Dram
        /// </summary>
        public static readonly Döviz Amd;

        /// <summary>
        /// Barbados Dollar
        /// </summary>
        public static readonly Döviz Bbd;

        /// <summary>
        /// Bermudian Dollar 
        /// (customarily known as 
        /// Bermuda Dollar)
        /// </summary>
        public static readonly Döviz Bmd;

        /// <summary>
        /// Boliviano
        /// </summary>
        public static readonly Döviz Bob;

        /// <summary>
        /// Pula
        /// </summary>
        public static readonly Döviz Bwp;

        /// <summary>
        /// Belize Dollar
        /// </summary>
        public static readonly Döviz Bzd;

        /// <summary>
        /// Solomon Islands Dollar
        /// </summary>
        public static readonly Döviz Sbd;

        /// <summary>
        /// Brunei Dollar
        /// </summary>
        public static readonly Döviz Bnd;

        /// <summary>
        /// Kyat
        /// </summary>
        public static readonly Döviz Mmk;

        /// <summary>
        /// Burundi Franc
        /// </summary>
        public static readonly Döviz Bif;

        /// <summary>
        /// Riel
        /// </summary>
        public static readonly Döviz Khr;

        /// <summary>
        /// Canadian Dollar
        /// </summary>
        public static readonly Döviz Cad;

        /// <summary>
        /// Cape Verde Escudo
        /// </summary>
        public static readonly Döviz Cve;

        /// <summary>
        /// Cayman Islands Dollar
        /// </summary>
        public static readonly Döviz Kyd;

        /// <summary>
        /// Sri Lanka Rupee
        /// </summary>
        public static readonly Döviz Lkr;

        /// <summary>
        /// Chilean Peso
        /// </summary>
        public static readonly Döviz Clp;

        /// <summary>
        /// Yuan Renminbi
        /// </summary>
        public static readonly Döviz Cny;

        /// <summary>
        /// Colombian Peso
        /// </summary>
        public static readonly Döviz Cop;

        /// <summary>
        /// Comoro Franc
        /// </summary>
        public static readonly Döviz Kmf;

        /// <summary>
        /// Costa Rican Colon
        /// </summary>
        public static readonly Döviz Crc;

        /// <summary>
        /// Croatian Kuna
        /// </summary>
        public static readonly Döviz Hrk;

        /// <summary>
        /// Cuban Peso
        /// </summary>
        public static readonly Döviz Cup;

        /// <summary>
        /// Czech Koruna
        /// </summary>
        public static readonly Döviz Czk;

        /// <summary>
        /// Danish Krone
        /// </summary>
        public static readonly Döviz Dkk;

        /// <summary>
        /// Dominican Peso
        /// </summary>
        public static readonly Döviz Dop;

        /// <summary>
        /// El Salvador Colon
        /// </summary>
        public static readonly Döviz Svc;

        /// <summary>
        /// Ethiopian Birr
        /// </summary>
        public static readonly Döviz Etb;

        /// <summary>
        /// Nakfa
        /// </summary>
        public static readonly Döviz Ern;

        /// <summary>
        /// Kroon
        /// </summary>
        public static readonly Döviz Eek;

        /// <summary>
        /// Falkland Islands Pound
        /// </summary>
        public static readonly Döviz Fkp;

        /// <summary>
        /// Fiji Dollar
        /// </summary>
        public static readonly Döviz Fjd;

        /// <summary>
        /// Djibouti Franc
        /// </summary>
        public static readonly Döviz Djf;

        /// <summary>
        /// Dalasi
        /// </summary>
        public static readonly Döviz Gmd;

        /// <summary>
        /// Gibraltar Pound
        /// </summary>
        public static readonly Döviz Gip;

        /// <summary>
        /// Quetzal
        /// </summary>
        public static readonly Döviz Gtq;

        /// <summary>
        /// Guinea Franc
        /// </summary>
        public static readonly Döviz Gnf;

        /// <summary>
        /// Guyana Dollar
        /// </summary>
        public static readonly Döviz Gyd;

        /// <summary>
        /// Gourde
        /// </summary>
        public static readonly Döviz Htg;

        /// <summary>
        /// Lempira
        /// </summary>
        public static readonly Döviz Hnl;

        /// <summary>
        /// Hong Kong Dollar
        /// </summary>
        public static readonly Döviz Hkd;

        /// <summary>
        /// Forint
        /// </summary>
        public static readonly Döviz Huf;

        /// <summary>
        /// Iceland Krona
        /// </summary>
        public static readonly Döviz Isk;

        /// <summary>
        /// Indian Rupee
        /// </summary>
        public static readonly Döviz Inr;

        /// <summary>
        /// Rupiah
        /// </summary>
        public static readonly Döviz Idr;

        /// <summary>
        /// Iranian Rial
        /// </summary>
        public static readonly Döviz Irr;

        /// <summary>
        /// Iraqi Dinar
        /// </summary>
        public static readonly Döviz Iqd;

        /// <summary>
        /// New Israeli Sheqel
        /// </summary>
        public static readonly Döviz Ils;

        /// <summary>
        /// Jamaican Dollar
        /// </summary>
        public static readonly Döviz Jmd;

        /// <summary>
        /// Yen
        /// </summary>
        public static readonly Döviz Jpy;

        /// <summary>
        /// Tenge
        /// </summary>
        public static readonly Döviz Kzt;

        /// <summary>
        /// Jordanian Dinar
        /// </summary>
        public static readonly Döviz Jod;

        /// <summary>
        /// Kenyan Shilling
        /// </summary>
        public static readonly Döviz Kes;

        /// <summary>
        /// North Korean Won
        /// </summary>
        public static readonly Döviz Kpw;

        /// <summary>
        /// Won
        /// </summary>
        public static readonly Döviz Krw;

        /// <summary>
        /// Kuwaiti Dinar
        /// </summary>
        public static readonly Döviz Kwd;

        /// <summary>
        /// Som
        /// </summary>
        public static readonly Döviz Kgs;

        /// <summary>
        /// Kip
        /// </summary>
        public static readonly Döviz Lak;

        /// <summary>
        /// Lebanese Pound
        /// </summary>
        public static readonly Döviz Lbp;

        /// <summary>
        /// Latvian Lats
        /// </summary>
        public static readonly Döviz Lvl;

        /// <summary>
        /// Liberian Dollar
        /// </summary>
        public static readonly Döviz Lrd;

        /// <summary>
        /// Libyan Dinar
        /// </summary>
        public static readonly Döviz Lyd;

        /// <summary>
        /// Lithuanian Litas
        /// </summary>
        public static readonly Döviz Ltl;

        /// <summary>
        /// Pataca
        /// </summary>
        public static readonly Döviz Mop;

        /// <summary>
        /// Kwacha
        /// </summary>
        public static readonly Döviz Mwk;

        /// <summary>
        /// Malaysian Ringgit
        /// </summary>
        public static readonly Döviz Myr;

        /// <summary>
        /// Rufiyaa
        /// </summary>
        public static readonly Döviz Mvr;

        /// <summary>
        /// Ouguiya
        /// </summary>
        public static readonly Döviz Mro;

        /// <summary>
        /// Mauritius Rupee
        /// </summary>
        public static readonly Döviz Mur;

        /// <summary>
        /// Mexican Peso
        /// </summary>
        public static readonly Döviz Mxn;

        /// <summary>
        /// Tugrik
        /// </summary>
        public static readonly Döviz Mnt;

        /// <summary>
        /// Moldovan Leu
        /// </summary>
        public static readonly Döviz Mdl;

        /// <summary>
        /// Moroccan Dirham
        /// </summary>
        public static readonly Döviz Mad;

        /// <summary>
        /// Rial Omani
        /// </summary>
        public static readonly Döviz Omr;

        /// <summary>
        /// Nepalese Rupee
        /// </summary>
        public static readonly Döviz Npr;

        /// <summary>
        /// Netherlands Antillian Guilder
        /// </summary>
        public static readonly Döviz Ang;

        /// <summary>
        /// Aruban Guilder
        /// </summary>
        public static readonly Döviz Awg;

        /// <summary>
        /// Vatu
        /// </summary>
        public static readonly Döviz Vuv;

        /// <summary>
        /// New Zealand Dollar
        /// </summary>
        public static readonly Döviz Nzd;

        /// <summary>
        /// Cordoba Oro
        /// </summary>
        public static readonly Döviz Nio;

        /// <summary>
        /// Naira
        /// </summary>
        public static readonly Döviz Ngn;

        /// <summary>
        /// Norwegian Krone
        /// </summary>
        public static readonly Döviz Nok;

        /// <summary>
        /// Pakistan Rupee
        /// </summary>
        public static readonly Döviz Pkr;

        /// <summary>
        /// Balboa
        /// </summary>
        public static readonly Döviz Pab;

        /// <summary>
        /// Kina
        /// </summary>
        public static readonly Döviz Pgk;

        /// <summary>
        /// Guarani
        /// </summary>
        public static readonly Döviz Pyg;

        /// <summary>
        /// Nuevo Sol
        /// </summary>
        public static readonly Döviz Pen;

        /// <summary>
        /// Philippine Peso
        /// </summary>
        public static readonly Döviz Php;

        /// <summary>
        /// Guinea-Bissau Peso
        /// </summary>
        public static readonly Döviz Gwp;

        /// <summary>
        /// Qatari Rial
        /// </summary>
        public static readonly Döviz Qar;

        /// <summary>
        /// Russian Ruble
        /// </summary>
        public static readonly Döviz Rub;

        /// <summary>
        /// Rwanda Franc
        /// </summary>
        public static readonly Döviz Rwf;

        /// <summary>
        /// Saint Helena Pound
        /// </summary>
        public static readonly Döviz Shp;

        /// <summary>
        /// Dobra
        /// </summary>
        public static readonly Döviz Std;

        /// <summary>
        /// Saudi Riyal
        /// </summary>
        public static readonly Döviz Sar;

        /// <summary>
        /// Seychelles Rupee
        /// </summary>
        public static readonly Döviz Scr;

        /// <summary>
        /// Leone
        /// </summary>
        public static readonly Döviz Sll;

        /// <summary>
        /// Singapore Dollar
        /// </summary>
        public static readonly Döviz Sgd;

        /// <summary>
        /// Slovak Koruna
        /// </summary>
        public static readonly Döviz Skk;

        /// <summary>
        /// Dong
        /// </summary>
        public static readonly Döviz Vnd;

        /// <summary>
        /// Somali Shilling
        /// </summary>
        public static readonly Döviz Sos;

        /// <summary>
        /// Rand
        /// </summary>
        public static readonly Döviz Zar;

        /// <summary>
        /// Zimbabwe Dollar
        /// </summary>
        public static readonly Döviz Zwd;

        /// <summary>
        /// Lilangeni
        /// </summary>
        public static readonly Döviz Szl;

        /// <summary>
        /// Swedish Krona
        /// </summary>
        public static readonly Döviz Sek;

        /// <summary>
        /// Swiss Franc
        /// </summary>
        public static readonly Döviz Chf;

        /// <summary>
        /// Syrian Pound
        /// </summary>
        public static readonly Döviz Syp;

        /// <summary>
        /// Baht
        /// </summary>
        public static readonly Döviz Thb;

        /// <summary>
        /// Pa'anga
        /// </summary>
        public static readonly Döviz Top;

        /// <summary>
        /// Trinidad and Tobago 
        /// Dollar
        /// </summary>
        public static readonly Döviz Ttd;

        /// <summary>
        /// UAE Dirham
        /// </summary>
        public static readonly Döviz Aed;

        /// <summary>
        /// Tunisian Dinar
        /// </summary>
        public static readonly Döviz Tnd;

        /// <summary>
        /// Manat
        /// </summary>
        public static readonly Döviz Tmm;

        /// <summary>
        /// Uganda Shilling
        /// </summary>
        public static readonly Döviz Ugx;

        /// <summary>
        /// Denar
        /// </summary>
        public static readonly Döviz Mkd;

        /// <summary>
        /// Egyptian Pound
        /// </summary>
        public static readonly Döviz Egp;

        /// <summary>
        /// Pound Sterling
        /// </summary>
        public static readonly Döviz Gbp;

        /// <summary>
        /// Tanzanian Shilling
        /// </summary>
        public static readonly Döviz Tzs;

        /// <summary>
        /// US Dollar
        /// </summary>
        public static readonly Döviz Usd;

        /// <summary>
        /// Peso Uruguayo
        /// </summary>
        public static readonly Döviz Uyu;

        /// <summary>
        /// Uzbekistan Sum
        /// </summary>
        public static readonly Döviz Uzs;

        /// <summary>
        /// Tala
        /// </summary>
        public static readonly Döviz Wst;

        /// <summary>
        /// Yemeni Rial
        /// </summary>
        public static readonly Döviz Yer;

        /// <summary>
        /// Kwacha
        /// </summary>
        public static readonly Döviz Zmk;

        /// <summary>
        /// New Taiwan Dollar
        /// </summary>
        public static readonly Döviz Twd;

        /// <summary>
        /// Ghana Cedi
        /// </summary>
        public static readonly Döviz Ghs;

        /// <summary>
        /// Bolivar Fuerte
        /// </summary>
        public static readonly Döviz Vef;

        /// <summary>
        /// Sudanese Pound
        /// </summary>
        public static readonly Döviz Sdg;

        /// <summary>
        /// Serbian Dinar
        /// </summary>
        public static readonly Döviz Rsd;

        /// <summary>
        /// Metical
        /// </summary>
        public static readonly Döviz Mzn;

        /// <summary>
        /// Azerbaijanian Manat
        /// </summary>
        public static readonly Döviz Azn;

        /// <summary>
        /// New Leu
        /// </summary>
        public static readonly Döviz Ron;

        /// <summary>
        /// New Turkish Lira
        /// </summary>
        public static readonly Döviz Try;

        /// <summary>
        /// CFA Franc BEAC
        /// </summary>
        public static readonly Döviz Xaf;

        /// <summary>
        /// East Caribbean Dollar
        /// </summary>
        public static readonly Döviz Xcd;

        /// <summary>
        /// CFA Franc BCEAO
        /// </summary>
        public static readonly Döviz Xof;

        /// <summary>
        /// CFP Franc
        /// </summary>
        public static readonly Döviz Xpf;

        /// <summary>
        /// Bond Markets Units 
        /// European Composite Unit 
        /// (EURCO)
        /// </summary>
        public static readonly Döviz Xba;

        /// <summary>
        /// European Monetary 
        /// Unit (E.M.U.-6)
        /// </summary>
        public static readonly Döviz Xbb;

        /// <summary>
        /// European Unit of 
        /// Account 9(E.U.A.-9)
        /// </summary>
        public static readonly Döviz Xbc;

        /// <summary>
        /// European Unit of 
        /// Account 17(E.U.A.-17)
        /// </summary>
        public static readonly Döviz Xbd;

        /// <summary>
        /// Gold
        /// </summary>
        public static readonly Döviz Xau;

        /// <summary>
        /// SDR
        /// </summary>
        public static readonly Döviz Xdr;

        /// <summary>
        /// Silver
        /// </summary>
        public static readonly Döviz Xag;

        /// <summary>
        /// Platinum
        /// </summary>
        public static readonly Döviz Xpt;

        /// <summary>
        /// Codes specifically 
        /// reserved for testing 
        /// purposes
        /// </summary>
        public static readonly Döviz Xts;

        /// <summary>
        /// Palladium
        /// </summary>
        public static readonly Döviz Xpd;

        /// <summary>
        /// Surinam Dollar
        /// </summary>
        public static readonly Döviz Srd;

        /// <summary>
        /// Malagasy Ariary
        /// </summary>
        public static readonly Döviz Mga;

        /// <summary>
        /// Afghani
        /// </summary>
        public static readonly Döviz Afn;

        /// <summary>
        /// Somoni
        /// </summary>
        public static readonly Döviz Tjs;

        /// <summary>
        /// Kwanza
        /// </summary>
        public static readonly Döviz Aoa;

        /// <summary>
        /// Belarussian Ruble
        /// </summary>
        public static readonly Döviz Byr;

        /// <summary>
        /// Bulgarian Lev
        /// </summary>
        public static readonly Döviz Bgn;

        /// <summary>
        /// Franc Congolais
        /// </summary>
        public static readonly Döviz Cdf;

        /// <summary>
        /// Convertible Marks
        /// </summary>
        public static readonly Döviz Bam;

        /// <summary>
        /// Euro
        /// </summary>
        public static readonly Döviz Eur;

        /// <summary>
        /// Hryvnia
        /// </summary>
        public static readonly Döviz Uah;

        /// <summary>
        /// Lari
        /// </summary>
        public static readonly Döviz Gel;

        /// <summary>
        /// Zloty
        /// </summary>
        public static readonly Döviz Pln;

        /// <summary>
        /// Brazilian Real
        /// </summary>
        public static readonly Döviz Brl;
        /// <summary>
        /// The codes assigned for 
        /// transactions where no 
        /// Döviz is involved.
        /// </summary>
        public static readonly Döviz Xxx;
        #endregion

        static Döviz()
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            Dictionary<String, List<Int32>> cultureIdLookup = new Dictionary<String, List<Int32>>();
            Dictionary<String, String> symbolLookup = new Dictionary<String, String>();

            foreach (CultureInfo culture in cultures)
            {
                Int32 lcid = culture.LCID;
                RegionInfo regionInfo = new RegionInfo(lcid);
                String isoSymbol = regionInfo.ISOCurrencySymbol;

                if (!cultureIdLookup.ContainsKey(isoSymbol))
                {
                    cultureIdLookup[isoSymbol] = new List<Int32>();
                }

                cultureIdLookup[isoSymbol].Add(lcid);
                symbolLookup[isoSymbol] = regionInfo.CurrencySymbol;
            }

            #region Döviz table loading
            _dövizler[008] = new DövizTableEntry("Lek", "ALL", 008, "", lookupString("ALL", symbolLookup));
            _dövizler[012] = new DövizTableEntry("Algerian Dinar", "DZD", 012, "santeem", lookupString("DZD", symbolLookup));
            _dövizler[032] = new DövizTableEntry("Argentine Peso", "ARS", 032, "centavo", lookupString("ARS", symbolLookup));
            _dövizler[036] = new DövizTableEntry("Australian Dollar", "AUD", 036, "cent", lookupString("AUD", symbolLookup));
            _dövizler[044] = new DövizTableEntry("Bahamian Dollar", "BSD", 044, "", lookupString("BSD", symbolLookup));
            _dövizler[048] = new DövizTableEntry("Bahraini Dinar", "BHD", 048, "", lookupString("BHD", symbolLookup));
            _dövizler[050] = new DövizTableEntry("Taka", "BDT", 050, "", lookupString("BDT", symbolLookup));
            _dövizler[051] = new DövizTableEntry("Armenian Dram", "AMD", 051, "", lookupString("AMD", symbolLookup));
            _dövizler[052] = new DövizTableEntry("Barbados Dollar", "BBD", 052, "", lookupString("BBD", symbolLookup));
            _dövizler[060] = new DövizTableEntry("Bermudian Dollar (customarily known as Bermuda Dollar)", "BMD", 060, "", lookupString("BMD", symbolLookup));
            _dövizler[068] = new DövizTableEntry("Boliviano", "BOB", 068, "", lookupString("BOB", symbolLookup));
            _dövizler[072] = new DövizTableEntry("Pula", "BWP", 072, "", lookupString("BWP", symbolLookup));
            _dövizler[084] = new DövizTableEntry("Belize Dollar", "BZD", 084, "", lookupString("BZD", symbolLookup));
            _dövizler[090] = new DövizTableEntry("Solomon Islands Dollar", "SBD", 090, "", lookupString("SBD", symbolLookup));
            _dövizler[096] = new DövizTableEntry("Brunei Dollar", "BND", 096, "", lookupString("BND", symbolLookup));
            _dövizler[104] = new DövizTableEntry("Kyat", "MMK", 104, "", lookupString("MMK", symbolLookup));
            _dövizler[108] = new DövizTableEntry("Burundi Franc", "BIF", 108, "", lookupString("BIF", symbolLookup));
            _dövizler[116] = new DövizTableEntry("Riel", "KHR", 116, "", lookupString("KHR", symbolLookup));
            _dövizler[124] = new DövizTableEntry("Canadian Dollar", "CAD", 124, "cent", lookupString("CAD", symbolLookup));
            _dövizler[132] = new DövizTableEntry("Cape Verde Escudo", "CVE", 132, "", lookupString("CVE", symbolLookup));
            _dövizler[136] = new DövizTableEntry("Cayman Islands Dollar", "KYD", 136, "", lookupString("KYD", symbolLookup));
            _dövizler[144] = new DövizTableEntry("Sri Lanka Rupee", "LKR", 144, "", lookupString("LKR", symbolLookup));
            _dövizler[152] = new DövizTableEntry("Chilean Peso", "CLP", 152, "", lookupString("CLP", symbolLookup));
            _dövizler[156] = new DövizTableEntry("Yuan Renminbi", "CNY", 156, "", lookupString("CNY", symbolLookup));
            _dövizler[170] = new DövizTableEntry("Colombian Peso", "COP", 170, "centavo", lookupString("COP", symbolLookup));
            _dövizler[174] = new DövizTableEntry("Comoro Franc", "KMF", 174, "", lookupString("KMF", symbolLookup));
            _dövizler[188] = new DövizTableEntry("Costa Rican Colon", "CRC", 188, "", lookupString("CRC", symbolLookup));
            _dövizler[191] = new DövizTableEntry("Croatian Kuna", "HRK", 191, "", lookupString("HRK", symbolLookup));
            _dövizler[192] = new DövizTableEntry("Cuban Peso", "CUP", 192, "", lookupString("CUP", symbolLookup));
            _dövizler[203] = new DövizTableEntry("Czech Koruna", "CZK", 203, "", lookupString("CZK", symbolLookup));
            _dövizler[208] = new DövizTableEntry("Danish Krone", "DKK", 208, "øre", lookupString("DKK", symbolLookup));
            _dövizler[214] = new DövizTableEntry("Dominican Peso", "DOP", 214, "", lookupString("DOP", symbolLookup));
            _dövizler[222] = new DövizTableEntry("El Salvador Colon", "SVC", 222, "", lookupString("SVC", symbolLookup));
            _dövizler[230] = new DövizTableEntry("Ethiopian Birr", "ETB", 230, "", lookupString("ETB", symbolLookup));
            _dövizler[232] = new DövizTableEntry("Nakfa", "ERN", 232, "", lookupString("ERN", symbolLookup));
            _dövizler[233] = new DövizTableEntry("Kroon", "EEK", 233, "", lookupString("EEK", symbolLookup));
            _dövizler[238] = new DövizTableEntry("Falkland Islands Pound", "FKP", 238, "", lookupString("FKP", symbolLookup));
            _dövizler[242] = new DövizTableEntry("Fiji Dollar", "FJD", 242, "", lookupString("FJD", symbolLookup));
            _dövizler[262] = new DövizTableEntry("Djibouti Franc", "DJF", 262, "", lookupString("DJF", symbolLookup));
            _dövizler[270] = new DövizTableEntry("Dalasi", "GMD", 270, "", lookupString("GMD", symbolLookup));
            _dövizler[292] = new DövizTableEntry("Gibraltar Pound", "GIP", 292, "", lookupString("GIP", symbolLookup));
            _dövizler[320] = new DövizTableEntry("Quetzal", "GTQ", 320, "", lookupString("GTQ", symbolLookup));
            _dövizler[324] = new DövizTableEntry("Guinea Franc", "GNF", 324, "", lookupString("GNF", symbolLookup));
            _dövizler[328] = new DövizTableEntry("Guyana Dollar", "GYD", 328, "", lookupString("GYD", symbolLookup));
            _dövizler[332] = new DövizTableEntry("Gourde", "HTG", 332, "", lookupString("HTG", symbolLookup));
            _dövizler[340] = new DövizTableEntry("Lempira", "HNL", 340, "", lookupString("HNL", symbolLookup));
            _dövizler[344] = new DövizTableEntry("Hong Kong Dollar", "HKD", 344, "cent", lookupString("HKD", symbolLookup));
            _dövizler[348] = new DövizTableEntry("Forint", "HUF", 348, "fillér", lookupString("HUF", symbolLookup));
            _dövizler[352] = new DövizTableEntry("Iceland Krona", "ISK", 352, "", lookupString("ISK", symbolLookup));
            _dövizler[356] = new DövizTableEntry("Indian Rupee", "INR", 356, "paisa", lookupString("INR", symbolLookup));
            _dövizler[360] = new DövizTableEntry("Rupiah", "IDR", 360, "", lookupString("IDR", symbolLookup));
            _dövizler[364] = new DövizTableEntry("Iranian Rial", "IRR", 364, "dinar", lookupString("IRR", symbolLookup));
            _dövizler[368] = new DövizTableEntry("Iraqi Dinar", "IQD", 368, "fils", lookupString("IQD", symbolLookup));
            _dövizler[376] = new DövizTableEntry("New Israeli Shekel", "ILS", 376, "agora", lookupString("ILS", symbolLookup));
            _dövizler[388] = new DövizTableEntry("Jamaican Dollar", "JMD", 388, "", lookupString("JMD", symbolLookup));
            _dövizler[392] = new DövizTableEntry("Yen", "JPY", 392, "sen", lookupString("JPY", symbolLookup));
            _dövizler[398] = new DövizTableEntry("Tenge", "KZT", 398, "", lookupString("KZT", symbolLookup));
            _dövizler[400] = new DövizTableEntry("Jordanian Dinar", "JOD", 400, "piastre", lookupString("JOD", symbolLookup));
            _dövizler[404] = new DövizTableEntry("Kenyan Shilling", "KES", 404, "cent", lookupString("KES", symbolLookup));
            _dövizler[408] = new DövizTableEntry("North Korean Won", "KPW", 408, "", lookupString("KPW", symbolLookup));
            _dövizler[410] = new DövizTableEntry("Won", "KRW", 410, "", lookupString("KRW", symbolLookup));
            _dövizler[414] = new DövizTableEntry("Kuwaiti Dinar", "KWD", 414, "fils", lookupString("KWD", symbolLookup));
            _dövizler[417] = new DövizTableEntry("Som", "KGS", 417, "", lookupString("KGS", symbolLookup));
            _dövizler[418] = new DövizTableEntry("Kip", "LAK", 418, "", lookupString("LAK", symbolLookup));
            _dövizler[422] = new DövizTableEntry("Lebanese Pound", "LBP", 422, "piastre", lookupString("LBP", symbolLookup));
            _dövizler[428] = new DövizTableEntry("Latvian Lats", "LVL", 428, "", lookupString("LVL", symbolLookup));
            _dövizler[430] = new DövizTableEntry("Liberian Dollar", "LRD", 430, "", lookupString("LRD", symbolLookup));
            _dövizler[434] = new DövizTableEntry("Libyan Dinar", "LYD", 434, "dirham", lookupString("LYD", symbolLookup));
            _dövizler[440] = new DövizTableEntry("Lithuanian Litas", "LTL", 440, "", lookupString("LTL", symbolLookup));
            _dövizler[446] = new DövizTableEntry("Pataca", "MOP", 446, "", lookupString("MOP", symbolLookup));
            _dövizler[454] = new DövizTableEntry("Kwacha", "MWK", 454, "", lookupString("MWK", symbolLookup));
            _dövizler[458] = new DövizTableEntry("Malaysian Ringgit", "MYR", 458, "", lookupString("MYR", symbolLookup));
            _dövizler[462] = new DövizTableEntry("Rufiyaa", "MVR", 462, "", lookupString("MVR", symbolLookup));
            _dövizler[478] = new DövizTableEntry("Ouguiya", "MRO", 478, "", lookupString("MRO", symbolLookup));
            _dövizler[480] = new DövizTableEntry("Mauritius Rupee", "MUR", 480, "", lookupString("MUR", symbolLookup));
            _dövizler[484] = new DövizTableEntry("Mexican Peso", "MXN", 484, "centavo", lookupString("MXN", symbolLookup));
            _dövizler[496] = new DövizTableEntry("Tugrik", "MNT", 496, "", lookupString("MNT", symbolLookup));
            _dövizler[498] = new DövizTableEntry("Moldovan Leu", "MDL", 498, "", lookupString("MDL", symbolLookup));
            _dövizler[504] = new DövizTableEntry("Moroccan Dirham", "MAD", 504, "santim", lookupString("MAD", symbolLookup));
            _dövizler[512] = new DövizTableEntry("Rial Omani", "OMR", 512, "baisa", lookupString("OMR", symbolLookup));
            _dövizler[524] = new DövizTableEntry("Nepalese Rupee", "NPR", 524, "", lookupString("NPR", symbolLookup));
            _dövizler[532] = new DövizTableEntry("Netherlands Antillian Guilder", "ANG", 532, "", lookupString("ANG", symbolLookup));
            _dövizler[533] = new DövizTableEntry("Aruban Guilder", "AWG", 533, "", lookupString("AWG", symbolLookup));
            _dövizler[548] = new DövizTableEntry("Vatu", "VUV", 548, "", lookupString("VUV", symbolLookup));
            _dövizler[554] = new DövizTableEntry("New Zealand Dollar", "NZD", 554, "", lookupString("NZD", symbolLookup));
            _dövizler[558] = new DövizTableEntry("Cordoba Oro", "NIO", 558, "", lookupString("NIO", symbolLookup));
            _dövizler[566] = new DövizTableEntry("Naira", "NGN", 566, "", lookupString("NGN", symbolLookup));
            _dövizler[578] = new DövizTableEntry("Norwegian Krone", "NOK", 578, "øre", lookupString("NOK", symbolLookup));
            _dövizler[586] = new DövizTableEntry("Pakistan Rupee", "PKR", 586, "paisa", lookupString("PKR", symbolLookup));
            _dövizler[590] = new DövizTableEntry("Balboa", "PAB", 590, "", lookupString("PAB", symbolLookup));
            _dövizler[598] = new DövizTableEntry("Kina", "PGK", 598, "", lookupString("PGK", symbolLookup));
            _dövizler[600] = new DövizTableEntry("Guarani", "PYG", 600, "", lookupString("PYG", symbolLookup));
            _dövizler[604] = new DövizTableEntry("Nuevo Sol", "PEN", 604, "", lookupString("PEN", symbolLookup));
            _dövizler[608] = new DövizTableEntry("Philippine Peso", "PHP", 608, "", lookupString("PHP", symbolLookup));
            _dövizler[624] = new DövizTableEntry("Guinea-Bissau Peso", "GWP", 624, "", lookupString("GWP", symbolLookup));
            _dövizler[634] = new DövizTableEntry("Qatari Rial", "QAR", 634, "dirham", lookupString("QAR", symbolLookup));
            _dövizler[643] = new DövizTableEntry("Russian Ruble", "RUB", 643, "kopek", lookupString("RUB", symbolLookup));
            _dövizler[646] = new DövizTableEntry("Rwanda Franc", "RWF", 646, "", lookupString("RWF", symbolLookup));
            _dövizler[654] = new DövizTableEntry("Saint Helena Pound", "SHP", 654, "", lookupString("SHP", symbolLookup));
            _dövizler[678] = new DövizTableEntry("Dobra", "STD", 678, "", lookupString("STD", symbolLookup));
            _dövizler[682] = new DövizTableEntry("Saudi Riyal", "SAR", 682, "halala", lookupString("SAR", symbolLookup));
            _dövizler[690] = new DövizTableEntry("Seychelles Rupee", "SCR", 690, "", lookupString("SCR", symbolLookup));
            _dövizler[694] = new DövizTableEntry("Leone", "SLL", 694, "", lookupString("SLL", symbolLookup));
            _dövizler[702] = new DövizTableEntry("Singapore Dollar", "SGD", 702, "", lookupString("SGD", symbolLookup));
            _dövizler[703] = new DövizTableEntry("Slovak Koruna", "SKK", 703, "", lookupString("SKK", symbolLookup));
            _dövizler[704] = new DövizTableEntry("Dong", "VND", 704, "", lookupString("VND", symbolLookup));
            _dövizler[706] = new DövizTableEntry("Somali Shilling", "SOS", 706, "", lookupString("SOS", symbolLookup));
            _dövizler[710] = new DövizTableEntry("Rand", "ZAR", 710, "", lookupString("ZAR", symbolLookup));
            _dövizler[716] = new DövizTableEntry("Zimbabwe Dollar", "ZWD", 716, "", lookupString("ZWD", symbolLookup));
            _dövizler[748] = new DövizTableEntry("Lilangeni", "SZL", 748, "", lookupString("SZL", symbolLookup));
            _dövizler[752] = new DövizTableEntry("Swedish Krona", "SEK", 752, "", lookupString("SEK", symbolLookup));
            _dövizler[756] = new DövizTableEntry("Swiss Franc", "CHF", 756, "centime", lookupString("CHF", symbolLookup));
            _dövizler[760] = new DövizTableEntry("Syrian Pound", "SYP", 760, "", lookupString("SYP", symbolLookup));
            _dövizler[764] = new DövizTableEntry("Baht", "THB", 764, "", lookupString("THB", symbolLookup));
            _dövizler[776] = new DövizTableEntry("Pa'anga", "TOP", 776, "", lookupString("TOP", symbolLookup));
            _dövizler[780] = new DövizTableEntry("Trinidad and Tobago Dollar", "TTD", 780, "", lookupString("TTD", symbolLookup));
            _dövizler[784] = new DövizTableEntry("UAE Dirham", "AED", 784, "fils", lookupString("AED", symbolLookup));
            _dövizler[788] = new DövizTableEntry("Tunisian Dinar", "TND", 788, "millim", lookupString("TND", symbolLookup));
            _dövizler[795] = new DövizTableEntry("Manat", "TMM", 795, "", lookupString("TMM", symbolLookup));
            _dövizler[800] = new DövizTableEntry("Uganda Shilling", "UGX", 800, "", lookupString("UGX", symbolLookup));
            _dövizler[807] = new DövizTableEntry("Denar", "MKD", 807, "", lookupString("MKD", symbolLookup));
            _dövizler[818] = new DövizTableEntry("Egyptian Pound", "EGP", 818, "piastre", lookupString("EGP", symbolLookup));
            _dövizler[826] = new DövizTableEntry("Pound Sterling", "GBP", 826, "penny", lookupString("GBP", symbolLookup));
            _dövizler[834] = new DövizTableEntry("Tanzanian Shilling", "TZS", 834, "", lookupString("TZS", symbolLookup));
            _dövizler[840] = new DövizTableEntry("US Dollar", "USD", 840, "cent", lookupString("USD", symbolLookup));
            _dövizler[858] = new DövizTableEntry("Peso Uruguayo", "UYU", 858, "", lookupString("UYU", symbolLookup));
            _dövizler[860] = new DövizTableEntry("Uzbekistan Sum", "UZS", 860, "", lookupString("UZS", symbolLookup));
            _dövizler[882] = new DövizTableEntry("Tala", "WST", 882, "", lookupString("WST", symbolLookup));
            _dövizler[886] = new DövizTableEntry("Yemeni Rial", "YER", 886, "", lookupString("YER", symbolLookup));
            _dövizler[894] = new DövizTableEntry("Kwacha", "ZMK", 894, "", lookupString("ZMK", symbolLookup));
            _dövizler[901] = new DövizTableEntry("New Taiwan Dollar", "TWD", 901, "", lookupString("TWD", symbolLookup));
            _dövizler[936] = new DövizTableEntry("Ghana Cedi", "GHS", 936, "", lookupString("GHS", symbolLookup));
            _dövizler[937] = new DövizTableEntry("Bolivar Fuerte", "VEF", 937, "", lookupString("VEF", symbolLookup));
            _dövizler[938] = new DövizTableEntry("Sudanese Pound", "SDG", 938, "piastre", lookupString("SDG", symbolLookup));
            _dövizler[941] = new DövizTableEntry("Serbian Dinar", "RSD", 941, "", lookupString("RSD", symbolLookup));
            _dövizler[943] = new DövizTableEntry("Metical", "MZN", 943, "", lookupString("MZN", symbolLookup));
            _dövizler[944] = new DövizTableEntry("Azerbaijanian Manat", "AZN", 944, "", lookupString("AZN", symbolLookup));
            _dövizler[946] = new DövizTableEntry("New Leu", "RON", 946, "", lookupString("RON", symbolLookup));
            _dövizler[949] = new DövizTableEntry("New Turkish Lira", "TRY", 949, "kuruş", lookupString("TRY", symbolLookup));
            _dövizler[950] = new DövizTableEntry("CFA Franc BEAC", "XAF", 950, "", lookupString("XAF", symbolLookup));
            _dövizler[951] = new DövizTableEntry("East Caribbean Dollar", "XCD", 951, "", lookupString("XCD", symbolLookup));
            _dövizler[952] = new DövizTableEntry("CFA Franc BCEAO", "XOF", 952, "", lookupString("XOF", symbolLookup));
            _dövizler[953] = new DövizTableEntry("CFP Franc", "XPF", 953, "", lookupString("XPF", symbolLookup));
            _dövizler[955] = new DövizTableEntry("Bond Markets Units European Composite Unit (EURCO)", "XBA", 955, "", lookupString("XBA", symbolLookup));
            _dövizler[956] = new DövizTableEntry("European Monetary Unit (E.M.U.-6)", "XBB", 956, "", lookupString("XBB", symbolLookup));
            _dövizler[957] = new DövizTableEntry("European Unit of Account 9(E.U.A.-9)", "XBC", 957, "", lookupString("XBC", symbolLookup));
            _dövizler[958] = new DövizTableEntry("European Unit of Account 17(E.U.A.-17)", "XBD", 958, "", lookupString("XBD", symbolLookup));
            _dövizler[959] = new DövizTableEntry("Gold", "XAU", 959, "", lookupString("XAU", symbolLookup));
            _dövizler[960] = new DövizTableEntry("SDR", "XDR", 960, "", lookupString("XDR", symbolLookup));
            _dövizler[961] = new DövizTableEntry("Silver", "XAG", 961, "", lookupString("XAG", symbolLookup));
            _dövizler[962] = new DövizTableEntry("Platinum", "XPT", 962, "", lookupString("XPT", symbolLookup));
            _dövizler[963] = new DövizTableEntry("Codes specifically reserved for testing purposes", "XTS", 963, "", lookupString("XTS", symbolLookup));
            _dövizler[964] = new DövizTableEntry("Palladium", "XPD", 964, "", lookupString("XPD", symbolLookup));
            _dövizler[968] = new DövizTableEntry("Surinam Dollar", "SRD", 968, "", lookupString("SRD", symbolLookup));
            _dövizler[969] = new DövizTableEntry("Malagasy Ariary", "MGA", 969, "", lookupString("MGA", symbolLookup));
            _dövizler[971] = new DövizTableEntry("Afghani", "AFN", 971, "", lookupString("AFN", symbolLookup));
            _dövizler[972] = new DövizTableEntry("Somoni", "TJS", 972, "", lookupString("TJS", symbolLookup));
            _dövizler[973] = new DövizTableEntry("Kwanza", "AOA", 973, "", lookupString("AOA", symbolLookup));
            _dövizler[974] = new DövizTableEntry("Belarussian Ruble", "BYR", 974, "", lookupString("BYR", symbolLookup));
            _dövizler[975] = new DövizTableEntry("Bulgarian Lev", "BGN", 975, "", lookupString("BGN", symbolLookup));
            _dövizler[976] = new DövizTableEntry("Franc Congolais", "CDF", 976, "", lookupString("CDF", symbolLookup));
            _dövizler[977] = new DövizTableEntry("Convertible Marks", "BAM", 977, "", lookupString("BAM", symbolLookup));
            _dövizler[978] = new DövizTableEntry("Euro", "EUR", 978, "cent", lookupString("EUR", symbolLookup));
            _dövizler[980] = new DövizTableEntry("Hryvnia", "UAH", 980, "", lookupString("UAH", symbolLookup));
            _dövizler[981] = new DövizTableEntry("Lari", "GEL", 981, "", lookupString("GEL", symbolLookup));
            _dövizler[985] = new DövizTableEntry("Zloty", "PLN", 985, "", lookupString("PLN", symbolLookup));
            _dövizler[986] = new DövizTableEntry("Brazilian Real", "BRL", 986, "", lookupString("BRL", symbolLookup));
            _dövizler[999] = new DövizTableEntry("The codes assigned for transactions where no Döviz is involved are:", "XXX", 999, "", lookupString("XXX", symbolLookup));
            #endregion

            foreach (DövizTableEntry Döviz in _dövizler.Values)
            {
                String iso3LetterCode = Döviz.Iso3LetterCode;
                List<Int32> lcids;

                if (cultureIdLookup.TryGetValue(iso3LetterCode, out lcids))
                {
                    foreach (Int32 lcid in lcids)
                    {
                        _cultureIdLookup[lcid] = Döviz.IsoNumberCode;
                    }
                }

                _codeIndex[iso3LetterCode] = Döviz.IsoNumberCode;
            }

            #region Intialize currencies
            All = new Döviz(008);
            Dzd = new Döviz(012);
            Ars = new Döviz(032);
            Aud = new Döviz(036);
            Bsd = new Döviz(044);
            Bhd = new Döviz(048);
            Bdt = new Döviz(050);
            Amd = new Döviz(051);
            Bbd = new Döviz(052);
            Bmd = new Döviz(060);
            Bob = new Döviz(068);
            Bwp = new Döviz(072);
            Bzd = new Döviz(084);
            Sbd = new Döviz(090);
            Bnd = new Döviz(096);
            Mmk = new Döviz(104);
            Bif = new Döviz(108);
            Khr = new Döviz(116);
            Cad = new Döviz(124);
            Cve = new Döviz(132);
            Kyd = new Döviz(136);
            Lkr = new Döviz(144);
            Clp = new Döviz(152);
            Cny = new Döviz(156);
            Cop = new Döviz(170);
            Kmf = new Döviz(174);
            Crc = new Döviz(188);
            Hrk = new Döviz(191);
            Cup = new Döviz(192);
            Czk = new Döviz(203);
            Dkk = new Döviz(208);
            Dop = new Döviz(214);
            Svc = new Döviz(222);
            Etb = new Döviz(230);
            Ern = new Döviz(232);
            Eek = new Döviz(233);
            Fkp = new Döviz(238);
            Fjd = new Döviz(242);
            Djf = new Döviz(262);
            Gmd = new Döviz(270);
            Gip = new Döviz(292);
            Gtq = new Döviz(320);
            Gnf = new Döviz(324);
            Gyd = new Döviz(328);
            Htg = new Döviz(332);
            Hnl = new Döviz(340);
            Hkd = new Döviz(344);
            Huf = new Döviz(348);
            Isk = new Döviz(352);
            Inr = new Döviz(356);
            Idr = new Döviz(360);
            Irr = new Döviz(364);
            Iqd = new Döviz(368);
            Ils = new Döviz(376);
            Jmd = new Döviz(388);
            Jpy = new Döviz(392);
            Kzt = new Döviz(398);
            Jod = new Döviz(400);
            Kes = new Döviz(404);
            Kpw = new Döviz(408);
            Krw = new Döviz(410);
            Kwd = new Döviz(414);
            Kgs = new Döviz(417);
            Lak = new Döviz(418);
            Lbp = new Döviz(422);
            Lvl = new Döviz(428);
            Lrd = new Döviz(430);
            Lyd = new Döviz(434);
            Ltl = new Döviz(440);
            Mop = new Döviz(446);
            Mwk = new Döviz(454);
            Myr = new Döviz(458);
            Mvr = new Döviz(462);
            Mro = new Döviz(478);
            Mur = new Döviz(480);
            Mxn = new Döviz(484);
            Mnt = new Döviz(496);
            Mdl = new Döviz(498);
            Mad = new Döviz(504);
            Omr = new Döviz(512);
            Npr = new Döviz(524);
            Ang = new Döviz(532);
            Awg = new Döviz(533);
            Vuv = new Döviz(548);
            Nzd = new Döviz(554);
            Nio = new Döviz(558);
            Ngn = new Döviz(566);
            Nok = new Döviz(578);
            Pkr = new Döviz(586);
            Pab = new Döviz(590);
            Pgk = new Döviz(598);
            Pyg = new Döviz(600);
            Pen = new Döviz(604);
            Php = new Döviz(608);
            Gwp = new Döviz(624);
            Qar = new Döviz(634);
            Rub = new Döviz(643);
            Rwf = new Döviz(646);
            Shp = new Döviz(654);
            Std = new Döviz(678);
            Sar = new Döviz(682);
            Scr = new Döviz(690);
            Sll = new Döviz(694);
            Sgd = new Döviz(702);
            Skk = new Döviz(703);
            Vnd = new Döviz(704);
            Sos = new Döviz(706);
            Zar = new Döviz(710);
            Zwd = new Döviz(716);
            Szl = new Döviz(748);
            Sek = new Döviz(752);
            Chf = new Döviz(756);
            Syp = new Döviz(760);
            Thb = new Döviz(764);
            Top = new Döviz(776);
            Ttd = new Döviz(780);
            Aed = new Döviz(784);
            Tnd = new Döviz(788);
            Tmm = new Döviz(795);
            Ugx = new Döviz(800);
            Mkd = new Döviz(807);
            Egp = new Döviz(818);
            Gbp = new Döviz(826);
            Tzs = new Döviz(834);
            Usd = new Döviz(840);
            Uyu = new Döviz(858);
            Uzs = new Döviz(860);
            Wst = new Döviz(882);
            Yer = new Döviz(886);
            Zmk = new Döviz(894);
            Twd = new Döviz(901);
            Ghs = new Döviz(936);
            Vef = new Döviz(937);
            Sdg = new Döviz(938);
            Rsd = new Döviz(941);
            Mzn = new Döviz(943);
            Azn = new Döviz(944);
            Ron = new Döviz(946);
            Try = new Döviz(949);
            Xaf = new Döviz(950);
            Xcd = new Döviz(951);
            Xof = new Döviz(952);
            Xpf = new Döviz(953);
            Xba = new Döviz(955);
            Xbb = new Döviz(956);
            Xbc = new Döviz(957);
            Xbd = new Döviz(958);
            Xau = new Döviz(959);
            Xdr = new Döviz(960);
            Xag = new Döviz(961);
            Xpt = new Döviz(962);
            Xts = new Döviz(963);
            Xpd = new Döviz(964);
            Srd = new Döviz(968);
            Mga = new Döviz(969);
            Afn = new Döviz(971);
            Tjs = new Döviz(972);
            Aoa = new Döviz(973);
            Byr = new Döviz(974);
            Bgn = new Döviz(975);
            Cdf = new Döviz(976);
            Bam = new Döviz(977);
            Eur = new Döviz(978);
            Uah = new Döviz(980);
            Gel = new Döviz(981);
            Pln = new Döviz(985);
            Brl = new Döviz(986);
            Xxx = new Döviz(999);
            #endregion

            //tod
        }

        /// <summary>
        /// Creates a <see cref="Döviz"/> instance from the 
        /// <see cref="CultureInfo.CurrentCulture"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="Döviz"/> which corresponds
        /// to the current culture.
        /// </returns>
        public static Döviz FromCurrentCulture()
        {
            return FromCultureInfo(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates a <see cref="Döviz"/> instance from the 
        /// given <see cref="CultureInfo"/>.
        /// </summary>
        /// <param name="cultureInfo">
        /// The <see cref="CultureInfo"/> from which to create the Döviz.
        /// </param>
        /// <returns>
        /// The <see cref="Döviz"/> which corresponds
        /// to <paramref name="cultureInfo"/>.
        /// </returns>
        public static Döviz FromCultureInfo(CultureInfo cultureInfo)
        {
            Int32 DövizId;

            if (_cultureIdLookup.TryGetValue(cultureInfo.LCID, out DövizId))
            {
                return new Döviz(DövizId);
            }

            throw new InvalidOperationException("Unknown culture: " + cultureInfo);
        }

        /// <summary>
        /// Creates a <see cref="Döviz"/> instance from its
        /// 3-letter ISO 4217 code.
        /// </summary>
        /// <param name="code">The ISO 4217 3-letter Döviz code.</param>
        /// <returns>
        /// The <see cref="Döviz"/> which corresponds
        /// to the ISO 4217 3-letter <paramref name="code"/>.
        /// </returns>
        public static Döviz FromIso3LetterCode(String code)
        {
            return new Döviz(code);
        }

        public static Boolean operator ==(Döviz left, Döviz right)
        {
            return left.Equals(right);
        }

        public static Boolean operator !=(Döviz left, Döviz right)
        {
            return !left.Equals(right);
        }

        private readonly Int32 _id;

        public Döviz(Int32 isoDövizCode)
        {
            if (!_dövizler.ContainsKey(isoDövizCode))
            {
                throw new ArgumentOutOfRangeException("isoDövizCode",
                                                      isoDövizCode,
                                                      "The value isn't a valid " +
                                                      "ISO 4217 numeric Döviz code.");
            }

            _id = isoDövizCode;

            TodaysRates = new Dictionary<DateTime, decimal>();
        }

        public Döviz(String iso3LetterCode)
        {
            Int32 DövizId;

            if (_codeIndex.TryGetValue(iso3LetterCode, out DövizId))
            {
                _id = DövizId;

                TodaysRates = new Dictionary<DateTime, decimal>();

                return;
            }

            throw new InvalidOperationException("Unknown Döviz code: " +
                                                iso3LetterCode);
        }

        public override Int32 GetHashCode()
        {
            return 609502847 ^ _id.GetHashCode();
        }

        public override Boolean Equals(Object obj)
        {
            if (!(obj is Döviz))
            {
                return false;
            }

            Döviz other = (Döviz)obj;
            return Equals(other);
        }

        public override String ToString()
        {
            return String.Format("{0} ({1})", Name, Iso3LetterCode);
        }

        #region IEquatable<Döviz> Members

        public Boolean Equals(Döviz other)
        {
            return _id == other._id;
        }

        #endregion

        #region IFormatProvider Members

        public Object GetFormat(Type formatType)
        {
            return formatType == typeof(NumberFormatInfo)
                        ? new CultureInfo(_id).NumberFormat
                        : null;
        }

        #endregion

        public String Name
        {
            get
            {
                DövizTableEntry entry = getEntry(_id);

                return entry.Name;
            }
        }

        public String Subunit
        {
            get
            {
                DövizTableEntry entry = getEntry(_id);

                return entry.Subunit;
            }
        }

        public String Symbol
        {
            get
            {
                DövizTableEntry entry = getEntry(_id);

                return entry.Symbol;
            }
        }

        public String Iso3LetterCode
        {
            get
            {
                DövizTableEntry entry = getEntry(_id);

                return entry.Iso3LetterCode;
            }
        }

        public Int32 IsoNumericCode
        {
            get
            {
                DövizTableEntry entry = getEntry(_id);

                return entry.IsoNumberCode;
            }
        }

        public bool IsActive { get; set; }

        public Dictionary<Int32, DövizTableEntry> Dövizler { get { return _dövizler; } }

        private static DövizTableEntry getEntry(Int32 id)
        {
            DövizTableEntry entry;

            if (!_dövizler.TryGetValue(id, out entry))
            {
                throw new InvalidOperationException("Unknown Döviz: " + id);
            }

            return entry;
        }

        private static String lookupString(String key, IDictionary<String, String> table)
        {
            String value;

            return !table.TryGetValue(key, out value) ? null : value;
        }
    }
}
