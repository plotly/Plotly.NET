namespace Plotly.NET

type StockData = 
    {
        Open           : float
        High           : float
        Low            : float
        Close          : float
    }
    with
    static member Create(o,h,l,c) = 
        {
            High           = h
            Low            = l
            Close          = c
            Open           = o
        }

    static member create o h l c =
        {
            High           = h
            Low            = l
            Close          = c
            Open           = o
        }