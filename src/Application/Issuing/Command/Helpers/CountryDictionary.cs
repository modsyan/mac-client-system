namespace MacClientSystem.Application.Issuing.Command.Helpers;

public class CountryDictionary
{
    private static readonly Dictionary<int, string?> NationsDictionary;
    private static readonly Dictionary<int, string?> StateDictionary;

    public static string? GetNation(int number) => NationsDictionary.TryGetValue(number, out string? countryName)
        ? countryName
        : "Country not found";

    public static string? GetStateName(int number) => StateDictionary.TryGetValue(number, out string? countryName)
        ? countryName
        : "Country not found";

    static CountryDictionary()
    {
        NationsDictionary = new Dictionary<int, string?>
        {
            { 1, "Ethiopian" },
            { 2, "Armenia" },
            { 3, "Spanish" },
            { 4, "Afghan" },
            { 5, "Albania" },
            { 6, "German" },
            { 7, "American" },
            { 8, "Indonesian" },
            { 9, "IRISH" },
            { 10, "Australian" },
            { 11, "Jordanian" },
            { 12, "UAE" },
            { 13, "Bahrain" },
            { 14, "Brazil" },
            { 15, "Algerian" },
            { 16, "Saudi" },
            { 17, "Senegal" },
            { 18, "Sudan" },
            { 19, "Sweden" },
            { 20, "Somalia" },
            { 21, "China" },
            { 22, "Iraqi" },
            { 23, "Philippines" },
            { 24, "Kuwaiti" },
            { 25, "Moroccan" },
            { 26, "British" },
            { 27, "Norway" },
            { 28, "Austria" },
            { 29, "Niger" },
            { 30, "Indian" },
            { 31, "Japan" },
            { 32, "Yemen" },
            { 33, "Greek" },
            { 34, "Uzbekistan" },
            { 35, "IRAN" },
            { 36, "Iceland" },
            { 37, "Italian" },
            { 38, "Pakistani" },
            { 39, "British" },
            { 40, "Belgian" },
            { 41, "Bangladesh" },
            { 42, "Beninese" },
            { 43, "Turki" },
            { 44, "Chadian" },
            { 45, "Tanzania" },
            { 46, "Tunisia" },
            { 47, "Finnish" },
            { 48, "Dominica" },
            { 49, "South Sudan" },
            { 50, "Djibouti" },
            { 51, "Russia" },
            { 52, "Romania" },
            { 53, "ST Kitts and Nevis" },
            { 54, "Sri Lanka" },
            { 55, "Slovakia" },
            { 56, "Syrian" },
            { 57, "Switzerland" },
            { 58, "Tajikistan" },
            { 59, "Guyana" },
            { 60, "French" },
            { 61, "Palestinian" },
            { 62, "Canadian" },
            { 63, "South Korean" },
            { 64, "Colombia" },
            { 65, "Kenya" },
            { 66, "Lebanese" },
            { 67, "Libyan" },
            { 68, "Malta" },
            { 69, "Mali" },
            { 70, "Malaysian" },
            { 71, "Egyptian" },
            { 72, "Moldova" },
            { 73, "Nepalese" },
            { 74, "Nigeria" },
            { 75, "Nederland" },
            { 76, "Comorienne" },
            { 77, "Denmark" },
            { 78, "Kazakhstan" },
            { 79, "Malawi" },
            { 80, "Ukraine" },
            { 81, "Poland" },
            { 82, "Qatar" },
            { 83, "Europe" },
            { 84, "Bulgarian" },
            { 85, "New Zealandish" },
            { 86, "Omani" },
            { 87, "Georgian" },
            { 88, "Serbian" },
            { 89, "Eritrean" },
            { 90, "Ghanaian" },
            { 91, "South Africa" },
            { 92, "Venezolana" },
            { 93, "Macedonian" },
            { 94, "Chile" },
            { 95, "Luxembourg" },
            { 96, "Myanmar" },
            { 97, "Portugal" },
            { 98, "Gambia" },
            { 99, "Kyrgyzstan" },
            { 100, "Peru" },
            { 101, "CONGO" },
            { 102, "Argentina" },
            { 103, "Ivory Coast" },
            { 104, "Cyprus" },
            { 105, "Guantanamo" },
            { 106, "Mexico" },
            { 107, "Hong Kong" },
            { 108, "Thailand" },
            { 109, "Singapore" },
            { 110, "Vietnam" },
            { 111, "North Korea" },
            { 112, "Taiwan" },
            { 113, "Angola" },
            { 114, "Cuba" },
            { 115, "Azerbaijan" },
            { 116, "Hungary" },
            { 117, "Belarus" },
            { 118, "Cameroon" },
            { 119, "Madagascar" },
            { 120, "Ecuador" },
            { 121, "Zimbabwe" },
            { 122, "Guinea" },
            { 123, "Uruguay" },
            { 124, "Zambia" },
            { 125, "Uganda" },
            { 126, "Haiti" },
            { 127, "Latvijas" },
            { 128, "Mauritania" },
            { 129, "Mongolia" },
            { 130, "Comoros" },
            { 131, "Seychelles" },
            { 132, "Vanuatu" },
            { 133, "Rwanda" },
            { 134, "Saint Lucia" },
            { 135, "ST.Kitts and Nevis" },
            { 136, "Republic of Mauritius" },
            { 137, "Croatia" },
            { 138, "Togo" },
            { 139, "CZECHIA" },
            { 140, "Antigua and Barbuda" },
            { 141, "Bosnia and Herzegovina" },
            { 142, "Lithuanian" },
        };

        StateDictionary = new Dictionary<int, string?>
        {
            { 1, "Ethiopia" },
            { 2, "Armenia" },
            { 3, "Spain" },
            { 4, "Afghanistan" },
            { 5, "Albania" },
            { 6, "Germany" },
            { 7, "USA" },
            { 8, "Indonesia" },
            { 9, "Ireland" },
            { 10, "Australian" },
            { 11, "Jordan" },
            { 12, "UAE" },
            { 13, "Bahrain" },
            { 14, "Brazil" },
            { 15, "Algeria" },
            { 16, "KSA" },
            { 17, "Senegal" },
            { 18, "Sudan" },
            { 19, "Sweden" },
            { 20, "Somalia" },
            { 21, "China" },
            { 22, "Iraq" },
            { 23, "Philippines" },
            { 24, "Kuwait" },
            { 25, "Morocco" },
            { 26, "United Kingdom" },
            { 27, "Norway" },
            { 28, "Austria" },
            { 29, "Niger" },
            { 30, "India" },
            { 31, "Japan" },
            { 32, "Yemen" },
            { 33, "Greece" },
            { 34, "Uzbekistan" },
            { 35, "IRAN" },
            { 36, "Iceland" },
            { 37, "Italy" },
            { 38, "Pakistan" },
            { 39, "Britain - UK" },
            { 40, "Belgium" },
            { 41, "Bangladesh" },
            { 42, "Benin" },
            { 43, "Turkey" },
            { 44, "Chad" },
            { 45, "Tanzania" },
            { 46, "Tunisian" },
            { 47, "Finland" },
            { 48, "Dominican Republic" },
            { 49, "South Sudan" },
            { 50, "Djibouti" },
            { 51, "Russia" },
            { 52, "Romania" },
            { 53, "ST Kitts and Nevis" },
            { 54, "Sri Lanka" },
            { 55, "Slovakia" },
            { 56, "Syria" },
            { 57, "Switzerland" },
            { 58, "Tajikistan" },
            { 59, "Guyana" },
            { 60, "France" },
            { 61, "Palestine" },
            { 62, "Canada" },
            { 63, "South Korean" },
            { 64, "Colombia" },
            { 65, "Kenya" },
            { 66, "Lebanon" },
            { 67, "Libya" },
            { 68, "Malta" },
            { 69, "Mali" },
            { 70, "Malaysia" },
            { 71, "Egypt" },
            { 72, "Moldova" },
            { 73, "Nepal" },
            { 74, "Nigeria" },
            { 75, "Holland" },
            { 76, "Union De Comores" },
            { 77, "Denmark" },
            { 78, "Kazakhstan" },
            { 79, "Malawi" },
            { 80, "Ukraine" },
            { 81, "Poland" },
            { 82, "Qatar" },
            { 83, "Europe" },
            { 84, "Bulgaria" },
            { 85, "New Zealand" },
            { 86, "Oman" },
            { 87, "Georgia" },
            { 88, "Serbia" },
            { 89, "Eritrea" },
            { 90, "Ghana" },
            { 91, "South Africa" },
            { 92, "Venezuela" },
            { 93, "Macedonia" },
            { 94, "Chile" },
            { 95, "Luxembourg" },
            { 96, "Myanmar" },
            { 97, "Portugal" },
            { 98, "Gambia" },
            { 99, "Kyrgyzstan" },
            { 100, "Peru" },
            { 101, "CONGO" },
            { 102, "Argentina" },
            { 103, "Ivory Coast" },
            { 104, "Cyprus" },
            { 105, "Guantanamo" },
            { 106, "Mexico" },
            { 107, "Hong Kong" },
            { 108, "Thailand" },
            { 109, "Singapore" },
            { 110, "Vietnam" },
            { 111, "North Korea" },
            { 112, "Taiwan" },
            { 113, "Angola" },
            { 114, "Cuba" },
            { 115, "Azerbaijan" },
            { 116, "Hungary" },
            { 117, "Belarus" },
            { 118, "Cameroon" },
            { 119, "Madagascar" },
            { 120, "Ecuador" },
            { 121, "Zimbabwe" },
            { 122, "Guinea" },
            { 123, "Uruguay" },
            { 124, "Zambia" },
            { 125, "Uganda" },
            { 126, "Haiti" },
            { 127, "Latvijas Republika" },
            { 128, "Mauritania" },
            { 129, "Mongolia" },
            { 130, "Comoros" },
            { 131, "Seychelles" },
            { 132, "Vanuatu" },
            { 133, "Rwanda" },
            { 134, "Saint Lucia" },
            { 135, "ST.Kitts and Nevis" },
            { 136, "Republic of Mauritius" },
            { 137, "Croatia" },
            { 138, "Togo" },
            { 139, "Czech Republic" },
            { 140, "Antigua and Barbuda" },
            { 141, "Bosnia and Herzegovina" },
            { 142, "Lithuania" },
        };
    }
}