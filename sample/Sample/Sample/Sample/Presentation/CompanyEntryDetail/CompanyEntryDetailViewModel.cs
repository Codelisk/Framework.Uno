using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Mvvm.ViewModels;
using Framework.Services.Services.Vms;

namespace Sample.Presentation.CompanyEntryDetail;
public partial class CompanyEntryDetailViewModel : RegionBaseViewModel
{
    public List<ProgrammingLanguageDto> Languages { get; set; } = new List<ProgrammingLanguageDto>
    {
        new ProgrammingLanguageDto{Name="C#"},
        new ProgrammingLanguageDto{Name="Java"}
    };
    public List<ProgrammingFrameworkDto> Frameworks { get; set; } = new List<ProgrammingFrameworkDto>
    {
        new ProgrammingFrameworkDto{ ProgrammingLanguageId = Guid.Empty, Name=".NET"},
        new ProgrammingFrameworkDto{ ProgrammingLanguageId = Guid.Empty, Name="Xamarin.Forms"}
    };
    public CompanyDto Company { get; set; } = new CompanyDto { Description = "Die Generali Österreich ist die drittgrößte heimische Versicherung. Als digitale Vorreiterin setzt das Unternehmen auf ein stetiges und nachhaltiges Wachstum. Mit internationalem Rückenwind: Hinter der Generali Österreich mit der Generali Versicherung, der BAWAG Versicherung und der Europäischen Reiseversicherung steht ein italienischer Weltkonzern. Mit über 75.000 Mitarbeiter*innen in 50 Ländern in Europa, Amerika, Asien und Afrika.\r\n\r\nDie Generali Österreich ist Arbeitgeberin von rund 5.000 Mitarbeiter*innen. Als Löwe steckt ihr der Mut in den Genen: Sei es nach außen, wo gelebter Innovationsgeist auf aktuelle Bewerberbedürfnisse trifft. Oder nach innen, wo Mitarbeiter*innen viel Gestaltungsfreiheit und Eigenverantwortung vorfinden. Ganz im Sinne des Arbeitgeberversprechens: Wir trauen uns vertrauen.\r\n\r\nOb Wirtschafts-, Finanz- oder Rechtsexpert*innen, IT- oder Vertriebsprofis – bei der Generali, dem Haus der 100 Berufe, fühlen sich Persönlichkeiten wohl, die gerne ihren eigenen Weg gehen und Verantwortung nicht scheuen. Menschen, die leistungswillig sind und Veränderung positiv sehen, aber auch Erfahrung zu schätzen wissen. Denn beim Generationenunternehmen verbindet sich Altes mit Neuem, Human Touch mit digitaler Kompetenz, Stabilität mit Zukunftsdrive.\r\n\r\nWas die Generali als Arbeitgeberin vor allem auszeichnet, ist ihre Vertrauenskultur. Das Unternehmen sieht sich nicht nur als lebenslange Partnerin ihrer Kund*innen, wo mit individuellen Angeboten auf veränderte Lebensbedingungen reagiert wird. Es sieht sich auch als Lifetime Partner für alle Mitarbeiter*innen. Die Basis dafür ist ein Klima voller Menschlichkeit und eine herausragende Aus- und Weiterbildung – ein ganzes Arbeitsleben hindurch.", Name = "Generali Österreich" };
    public CompanyEntryDetailViewModel(VmServices vmServices) : base(vmServices)
    {
    }
}
