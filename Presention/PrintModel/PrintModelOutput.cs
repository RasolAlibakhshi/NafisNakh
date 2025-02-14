namespace Presention.PrintModel
{
    public class PrintModelOutput
    {
        public string Interwoven { set; get; }
        public string Filament { set; get; }
        public string Den { set; get; }
        public string Ply { set; get; }
        public string Mingle { set; get; }
        public string Personcode { set; get; }
        public string MachineCode { set; get; }
        public long NumberStr { set; get; }
        public long NumberEnd { set; get; }
        public string Date { set; get; }

        public PrintModelOutput(string interwoven, string filament, string den, string ply, string mingle, string machineCode, string date)
        {
            Interwoven = interwoven;
            Filament = filament;
            Den = den;
            Ply = ply;
            Mingle = mingle;
            
            MachineCode = machineCode;
            
            Date = date;
        }
    }
}
