using PawsTrack.Application.DTOs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace PawsTrack.Presentation.Helpers
{
    internal static class BillingReportPdfGenerator
    {
        public static void Generate(
            string filePath,
            IReadOnlyList<BillReportRowDto> rows,
            string? clientFilter,
            DateTime from,
            DateTime to)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(30);
                    page.DefaultTextStyle(x => x.FontSize(9).FontFamily("Segoe UI"));

                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span($"Generated on {DateTime.Now:dd/MM/yyyy HH:mm}");
                        x.DefaultTextStyle(s => s.FontSize(8).FontColor(Colors.Grey.Medium));
                    });
                });
            }).GeneratePdf(filePath);

            void ComposeHeader(IContainer container)
            {
                container.Column(col =>
                {
                    col.Item().Row(row =>
                    {
                        row.RelativeItem().Column(inner =>
                        {
                            inner.Item().Text("PawsTrack")
                                .Bold().FontSize(18).FontColor(Colors.Blue.Darken3);
                            inner.Item().Text("Billing Report")
                                .FontSize(12).FontColor(Colors.Grey.Darken2);
                            inner.Item().Text($"Period: {from:dd/MM/yyyy} – {to:dd/MM/yyyy}")
                                .FontSize(9).FontColor(Colors.Grey.Medium);
                            if (!string.IsNullOrWhiteSpace(clientFilter))
                                inner.Item().Text($"Client filter: {clientFilter}")
                                    .FontSize(9).FontColor(Colors.Grey.Medium);
                        });
                    });

                    col.Item().PaddingTop(4).LineHorizontal(1).LineColor(Colors.Blue.Darken3);
                });
            }

            void ComposeContent(IContainer container)
            {
                container.PaddingTop(8).Table(table =>
                {
                    table.ColumnsDefinition(cols =>
                    {
                        cols.ConstantColumn(25);   // #
                        cols.RelativeColumn(3);    // Client
                        cols.RelativeColumn(2);    // Dog
                        cols.RelativeColumn(2);    // Walk Date
                        cols.RelativeColumn(1);    // Hrs
                        cols.RelativeColumn(1.5f); // Rate/hr
                        cols.RelativeColumn(1.5f); // Discount
                        cols.RelativeColumn(1.5f); // Total
                    });

                    // Header row
                    table.Header(header =>
                    {
                        void HeaderCell(string text) =>
                            header.Cell().Background(Colors.Blue.Darken3).Padding(4)
                                  .Text(text).Bold().FontColor(Colors.White).FontSize(8);

                        HeaderCell("#");
                        HeaderCell("Client");
                        HeaderCell("Dog");
                        HeaderCell("Walk Date");
                        HeaderCell("Hrs");
                        HeaderCell("Rate/hr");
                        HeaderCell("Discount");
                        HeaderCell("Total");
                    });

                    // Data rows
                    for (int i = 0; i < rows.Count; i++)
                    {
                        var row = rows[i];
                        string bg = i % 2 == 0 ? Colors.White : Colors.Grey.Lighten4;

                        table.Cell().Background(bg).Padding(4).Text((i + 1).ToString()).FontSize(8);
                        table.Cell().Background(bg).Padding(4).Text(row.ClientName).FontSize(8);
                        table.Cell().Background(bg).Padding(4).Text(row.DogName).FontSize(8);
                        table.Cell().Background(bg).Padding(4)
                             .Text($"{row.WalkDate:ddd dd/MM/yy} {row.StartTime:HH:mm}–{row.EndTime:HH:mm}").FontSize(8);
                        table.Cell().Background(bg).Padding(4).AlignRight()
                             .Text($"{row.DurationHours:F1}").FontSize(8);
                        table.Cell().Background(bg).Padding(4).AlignRight()
                             .Text(row.RatePerHour.ToString("C")).FontSize(8);
                        table.Cell().Background(bg).Padding(4).AlignRight()
                             .Text(row.Discount.ToString("C")).FontSize(8);
                        table.Cell().Background(bg).Padding(4).AlignRight()
                             .Text(row.TotalAmount.ToString("C")).Bold().FontSize(8);
                    }

                    // Grand total row
                    decimal grandTotal = rows.Sum(r => r.TotalAmount);
                    table.Cell().ColumnSpan(7).Background(Colors.Blue.Lighten4).Padding(5)
                         .AlignRight().Text("Grand Total").Bold().FontSize(9);
                    table.Cell().Background(Colors.Blue.Lighten4).Padding(5)
                         .AlignRight().Text(grandTotal.ToString("C")).Bold().FontSize(9)
                         .FontColor(Colors.Blue.Darken3);
                });
            }
        }
    }
}
