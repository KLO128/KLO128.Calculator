using KLO128.Calculator.Domain.Shared.Models;

namespace KLO128.Calculator.Domain.Services.Impl
{
    public static class ExpressionContextTreeExt
    {
        public static Token FirstToken(this ExpressionContextTree? context)
        {
            while (context != null && context.Token == null)
            {
                context = context.Children.FirstOrDefault();
            }

            return context?.Token ?? new Token("n.a.", -1);
        }

        public static void AddChild(this ExpressionContextTree parent, ExpressionContextTree item)
        {
            InsertItem(parent, item, false);
        }

        public static void AddSister(this ExpressionContextTree parent, ExpressionContextTree item)
        {
            InsertItem(parent, item, true);
        }

        public static void AddSister(this ExpressionContextTree parent, Token token)
        {
            InsertItem(parent, new ExpressionContextTree(token), true);
        }

        public static bool IsEmpty(this ExpressionContextTree parent)
        {
            return parent.Token == null && parent.Children.Count == 0;
        }

        private static void InsertItem(ExpressionContextTree parent, ExpressionContextTree item, bool itemIsSister)
        {
            if (parent.Token != null)
            {
                parent.Insert(new ExpressionContextTree(parent.Token));
                parent.Token = null;
            }

            if (itemIsSister)
            {
                if (item.Token != null)
                {
                    if (parent.Children.Count == 0)
                    {
                        parent.Token = item.Token;

                        return;
                    }
                    else
                    {
                        parent.Children.AddLast(item);
                    }
                }
                else
                {
                    var next = item.Children.First;

                    while (next?.Value != null)
                    {
                        parent.Children.AddLast(next.Value);
                        next = next.Next;
                    }
                }
            }
            else
            {
                parent.Insert(item);
            }
        }

        private static void Insert(this ExpressionContextTree parent, ExpressionContextTree item)
        {
            parent.Children.AddLast(item);
        }
    }
}
