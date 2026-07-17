using System;
using System.Collections.Generic;

namespace EasyBiz
{
    // Describes one launchable module/form in the app.
    public class ModuleInfo
    {
        public string Key { get; set; }          // stable identifier, stored in DB
        public string DisplayName { get; set; }   // shown to user
        public Type FormType { get; set; }        // the WinForms form to open
    }

    public static class ModuleRegistry
    {
        // Central list of everything that CAN be favourited.
        // Add new modules here only — nothing else needs to change.
        public static readonly List<ModuleInfo> AllModules = new List<ModuleInfo>
        {
            new ModuleInfo { Key = "aiassistant",     DisplayName = "AI Assistant", FormType = typeof(AIChatForm) },
            new ModuleInfo { Key = "cashpayment",     DisplayName = "Cash Payment",      FormType = typeof(CashPayments) },
            new ModuleInfo { Key = "cashreceipt",     DisplayName = "Cash Receipt",      FormType = typeof(CashReceipts) },
            new ModuleInfo { Key = "journalvoucher",  DisplayName = "Journal Voucher",   FormType = typeof(JournalVoucher) },
            new ModuleInfo { Key = "saleinvoice",     DisplayName = "Sale Invoice",      FormType = typeof(SaleInvoice) },
            new ModuleInfo { Key = "purchaseinvoice", DisplayName = "Purchase Invoice",  FormType = typeof(PurchaseInvoice) },
            new ModuleInfo { Key = "bankpayment",     DisplayName = "Bank Payment",  FormType = typeof(BankPayment) },
            new ModuleInfo { Key = "bankreceipt",     DisplayName = "Bank Receipt",  FormType = typeof(BankReceipt) },
            new ModuleInfo { Key = "cashbook",        DisplayName = "Cash Book",  FormType = typeof(CashBook) },
            new ModuleInfo { Key = "accountssetup",   DisplayName = "Accounts Setup",  FormType = typeof(AccountsSetup) },
            new ModuleInfo { Key = "chequebook",      DisplayName = "Cheque Book",  FormType = typeof(ChequeBook) },
            new ModuleInfo { Key = "edittransactions",DisplayName = "Edit Transactions",  FormType = typeof(EditTransactions) },
            new ModuleInfo { Key = "openingbalances", DisplayName = "Opening Balances",  FormType = typeof(OpeningBalances) },
            new ModuleInfo { Key = "productsetup",    DisplayName = "Product Setup",  FormType = typeof(ProductSetup) },
            new ModuleInfo { Key = "stockreport",     DisplayName = "Stock Report",  FormType = typeof(StockReport) },
            new ModuleInfo { Key = "settings",        DisplayName = "Settings",  FormType = typeof(Settings) },
            new ModuleInfo { Key = "viewledger",      DisplayName = "View Ledger",  FormType = typeof(ViewLedger) }
            // add more here...

            
        };
       

        public static ModuleInfo GetByKey(string key)
        {
            return AllModules.Find(m => m.Key == key);
        }

        
    }
}