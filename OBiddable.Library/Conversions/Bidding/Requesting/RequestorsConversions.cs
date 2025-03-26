using System.Text;
using OBiddable.Library.Bidding;
using OBiddable.Library.Bidding.Requesting;

namespace OBiddable.Library.Conversions.Bidding.Requesting;

public static class RequestorsConversions
{
    private const string _requestorCSVHeader = "name,code,buildingname,password,accountnumbers,amountbudgeted";
    public static string GenerateBlankRequestorsImportTemplate()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(_requestorCSVHeader);

        return sb.ToString();
    }
    public static List<Requestor> ConvertCSVToRequestors(this string[] fileData, out string error)
    {
        List<Requestor> output = new List<Requestor>();
        StringBuilder err = new StringBuilder();

        if (fileData[0].ToLower().Trim() != _requestorCSVHeader)
        {
            err.AppendLine($"fatal error: file header does not match");
            error = err.ToString();
            return null;
        }
        for (int x = 1; x < fileData.Length; x++)
        {
            if (fileData[x].Trim() == "")
            {
                err.AppendLine($"line skip: line blank ( line:{ x } )");
                continue;
            }
            string[] flds = fileData[x].ParseCSVRow();

            Requestor r = new Requestor();

            // name
            string name = flds[0];
            if (name == "" || name.Length > 255 || output.Any(q => q.Name == name))
            {
                err.AppendLine($"line skip: name string too long/short/or reused ( line:{ x } )");
                continue;
            }
            r.Name = name;

            // code
            int code = 0;
            if (!int.TryParse(flds[1], out code))
            {
                err.AppendLine($"line skip: code invalid ( line:{ x } )");
                error = err.ToString();
                return null;
            }
            r.Code = code;

            // building
            string building = flds[2];
            if (building.Length == 0 || building.Length > 255)
            {
                err.AppendLine($"line skip: building string too long/blank ( line:{ x } )");
                continue;
            }
            r.Building = building;

            // password
            string password = flds[3];
            if (password.Length == 0 || password.Length > 255)
            {
                err.AppendLine($"line skip: password string too long/blank ( line:{ x } )");
                continue;
            }
            r.Password = password;

            decimal amountBudgeted = 0;
            if (decimal.TryParse(flds[4], out amountBudgeted) && amountBudgeted > 0)
            {
                r.AmountBudgeted = amountBudgeted;
            }

            // requests
            r.Requests = new List<Request>();
            string[] accountNumbers = flds[4].Split(';');
            foreach (var accnt in accountNumbers)
            {
                if (accnt.Trim() == "")
                {
                    //err.AppendLine($"acc skip: blank value ( line:{ x }, accnt:{accnt} )");
                    continue;
                }
                if (r.Requests.Any(q => q.Account_Number == accnt))
                {
                    err.AppendLine($"acc skip: accnt already used ( line:{ x }, accnt:{accnt} )");
                    continue;
                }
                if (AccountNumber.IsInvalid(accnt))
                {
                    err.AppendLine($"acc skip: invalid account number format ( line:{ x }, accnt:{accnt} )");
                    continue;
                }
                Request request = new Request();
                request.Account_Number = accnt;
                r.Requests.Add(request);
            }

            output.Add(r);
        }

        error = err.ToString();
        return output;
    }
    public static string ConvertRequestorsToCSV(int bidId, IRequestingRepo requestingRepo)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(_requestorCSVHeader);

        var requestors = requestingRepo.GetRequestors_ByBid(bidId);
        foreach (Requestor r in requestors)
        {
            string[] accountNumbers = r.Requests.Select(x => x.Account_Number).ToArray();


            sb.AppendLine(
                $"{ r.Name.strip().surround() }," +
                $"{ r.FormattedCode }," +
                $"{ r.Building.strip().surround() }," +
                $"{ r.Password.strip().surround() }," +
                $"{ string.Join(";", accountNumbers)}," +
                $"{ (r.AmountBudgeted.HasValue ? r.AmountBudgeted.Value.ToString("0.00") : "0.00") }"
            );
        }

        return sb.ToString();
    }
}
