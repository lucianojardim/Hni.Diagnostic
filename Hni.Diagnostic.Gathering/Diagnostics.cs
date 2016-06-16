using System;

namespace Hni.Diagnostic.Gathering
{
    public class DiagnosticInformation
    {
        public DiagnosticInformation()
        {
        }
        public DiagnosticInformation(string diagnosticSource, string diagnosticDescription, string diagnosticData)
        {
            DiagnosticSource = diagnosticSource;
            DiagnosticDescription = diagnosticDescription;
            DiagnosticData = diagnosticData;
        }
        public DiagnosticInformation(string diagnosticSource, string diagnosticData)
        {
            DiagnosticSource = diagnosticSource;
            DiagnosticDescription = null;
            DiagnosticData = diagnosticData;
        }

        public string DiagnosticSource { get; set; }
        public string DiagnosticDescription { get; set; }
        public string DiagnosticData { get; set; }

        public void Save()
        {
            if (DiagnosticSource == null)
            {
                DiagnosticSource = "The caller didn't identified itself.";
            }

            if (DiagnosticData == null)
            {
                DiagnosticData = "No diagnostic information was sent.";
            }

            try
            {
                HniDiagnosticEntities hniDiagnosticEntities = new HniDiagnosticEntities();

                Diagnostic diagnostic = new Diagnostic();
                diagnostic.DiagnosticSource = DiagnosticSource;
                diagnostic.DiagnosticDateTime = System.DateTime.Now;
                diagnostic.DiagnosticDescription = DiagnosticDescription;
                diagnostic.DiagnosticData = DiagnosticData;

                hniDiagnosticEntities.Diagnostics.Add(diagnostic);
                hniDiagnosticEntities.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
