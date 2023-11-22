using KLO128.Calculator.Domain.Shared.Models;
using KLO128.Calculator.Domain.Shared.Models.Expressions;

namespace KLO128.Calculator.Tests.UnitTests.Domain.Mocks
{
    public static class TestDataContainer
    {
        public static Dictionary<string, bool> NumberFormatsValidation { get; } = new Dictionary<string, bool>
        {
            {
                "55 000",
                true
            },
            {
                "55,000.010",
                true
            },
            {
                "55 000.010",
                true
            },
            {
                "55 000,010",
                true
            },
            {
                "55 000,01",
                true
            },
            {
                "55,000,010",
                true
            },
            {
                "55,000,010.00",
                true
            },
            {
                ",000,010.00",
                false
            },
            {
                "- 500 000 010.00",
                true
            },
            {
                "- 500 000 010,00",
                true
            },
            {
                "500  000 010.00",
                false
            },
            {
                "500  000 010,00",
                false
            },
            {
                "500000,,010.00",
                false
            },
            {
                "5000,010.00",
                false
            },
            {
                "500,,010.00",
                false
            },
            {
                "500,010..00",
                false
            },
            {
                "500000010.00",
                true
            },
            {
                "--500000010.00",
                false
            },
            {
                 "50000001000",
                 true
            },
            {
                 "50000001000x",
                 false
            }
        };

        public static Dictionary<string, ExpressionData> Expressions { get; } = new Dictionary<string, ExpressionData>()
        {

            {
                Tests.Expressions.Expression1, new ExpressionData
                {
                    Culture = new Dictionary<string, ExpressionData.CultureData>
                    {
                        {
                            "cs-CZ",
                            new ExpressionData.CultureData
                            {

                                PrettyPrint = "( 5257,8475 * -( 5 + 3 ) )",
                                PrettyPrintWithSeparators = "( 5 257,8475 * -( 5 + 3 ) )",
                                ResultString = "-42062.78",
                                ResultStringWithSeparators = "-42 062,78",
                                Tokens = new List<Token> {new Token("("), new Token("5257.8475"), new OP("*"), new OP("-"), new Token("("), new Token("5"), new OP("+"), new Token("3"), new Token(")"), new Token(")")},
                                Warning = null,
                                Tree =
                                new ExpressionContextTree(new Token("placeholder"))
                                {
                                    Token = null,
                                    Warning = null,
                                    Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                    {

                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new Token("5257.8475"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new OP("*"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("-1"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new OP("*"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = null,
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("5"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                                                                            {

                                                                                                                                                                                                            })
                                                                                                                                                                                                        },


                                                                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new OP("+"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                                                                            {

                                                                                                                                                                                                            })
                                                                                                                                                                                                        },


                                                                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("3"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                                                                            {

                                                                                                                                                                                                            })
                                                                                                                                                                                                        },


                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                })
                                                                                                            },


                                                                        })
                                                                    },


                                    })
                                },

                                BinaryExpression =
                                new BinaryExpression
                                {
                                    Token = null,
                                    Warning = null,
                                    Strength = OPStrength.Power,
                                    StartIndex = 0,
                                    EndIndex = 9,
                                    Inner =
                                                                    new BracketExpression
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Strength = OPStrength.Multiple,
                                                                        StartIndex = 1,
                                                                        EndIndex = 8,
                                                                        Inner =
                                                                                                            new BinaryExpression
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.Multiple,
                                                                                                                StartIndex = 1,
                                                                                                                EndIndex = 1,
                                                                                                                Inner =
                                                                                                                                                        new BinaryExpression
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("5257.8475"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Strength = OPStrength.Multiple,
                                                                                                                                                            StartIndex = 1,
                                                                                                                                                            EndIndex = 1,
                                                                                                                                                            Inner = null,
                                                                                                                                                            Appendix = null
                                                                                                                                                        }
                                                                                                                                                        ,
                                                                                                                Appendix = null
                                                                                                            }
                                                                                                            ,
                                                                        Appendix =
                                                                                                            new AppendixExpression(new OP("*", OPStrength.Multiple, 10), 3, -1)
                                                                                                            {
                                                                                                                Inner =
                                                                                                                                                        new BracketExpression
                                                                                                                                                        {
                                                                                                                                                            Token = null,
                                                                                                                                                            Warning = null,
                                                                                                                                                            Strength = OPStrength.Add,
                                                                                                                                                            StartIndex = 3,
                                                                                                                                                            EndIndex = 7,
                                                                                                                                                            Inner =
                                                                                                                                                                                                        new BinaryExpression
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("-1"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Strength = OPStrength.LogicalOR,
                                                                                                                                                                                                            StartIndex = -1,
                                                                                                                                                                                                            EndIndex = -1,
                                                                                                                                                                                                            Inner = null,
                                                                                                                                                                                                            Appendix = null
                                                                                                                                                                                                        }
                                                                                                                                                                                                        ,
                                                                                                                                                            Appendix =
                                                                                                                                                                                                        new AppendixExpression(new OP("*", OPStrength.Multiple, 12), 4, -1)
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Inner =
                                                                                                                                                                                                                                                            new BracketExpression
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                Token = null,
                                                                                                                                                                                                                                                                Warning = null,
                                                                                                                                                                                                                                                                Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                StartIndex = 5,
                                                                                                                                                                                                                                                                EndIndex = 7,
                                                                                                                                                                                                                                                                Inner =
                                                                                                                                                                                                                                                                                                                    new BinaryExpression
                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                        Token = null,
                                                                                                                                                                                                                                                                                                                        Warning = null,
                                                                                                                                                                                                                                                                                                                        Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                        StartIndex = 5,
                                                                                                                                                                                                                                                                                                                        EndIndex = 5,
                                                                                                                                                                                                                                                                                                                        Inner =
                                                                                                                                                                                                                                                                                                                                                                                new BinaryExpression
                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                    Token = new Token("5"),
                                                                                                                                                                                                                                                                                                                                                                                    Warning = null,
                                                                                                                                                                                                                                                                                                                                                                                    Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                                                                                    StartIndex = 5,
                                                                                                                                                                                                                                                                                                                                                                                    EndIndex = 5,
                                                                                                                                                                                                                                                                                                                                                                                    Inner = null,
                                                                                                                                                                                                                                                                                                                                                                                    Appendix = null
                                                                                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                                                                                                ,
                                                                                                                                                                                                                                                                                                                        Appendix = null
                                                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                                                    ,
                                                                                                                                                                                                                                                                Appendix =
                                                                                                                                                                                                                                                                                                                    new AppendixExpression(new OP("+", OPStrength.Add, 14), 7, -1)
                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                        Inner =
                                                                                                                                                                                                                                                                                                                                                                                new BinaryExpression
                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                    Token = new Token("3"),
                                                                                                                                                                                                                                                                                                                                                                                    Warning = null,
                                                                                                                                                                                                                                                                                                                                                                                    Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                                                                                    StartIndex = 7,
                                                                                                                                                                                                                                                                                                                                                                                    EndIndex = 7,
                                                                                                                                                                                                                                                                                                                                                                                    Inner = null,
                                                                                                                                                                                                                                                                                                                                                                                    Appendix = null
                                                                                                                                                                                                                                                                                                                                                                                }

                                                                                                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                                            }

                                                                                                                                                                                                        }

                                                                                                                                                        }

                                                                                                            }

                                                                    }
                                                                    ,
                                    Appendix = null
                                }


                            }
                        },
                        {
                            "en-US",
                            new ExpressionData.CultureData
                            {

                                PrettyPrint = "( 5257.8475 * -( 5 + 3 ) )",
                                PrettyPrintWithSeparators = "( 5,257.8475 * -( 5 + 3 ) )",
                                ResultString = "-42062.78",
                                ResultStringWithSeparators = "-42,062.78",
                                Tokens = new List<Token> {new Token("("), new Token("5257.8475"), new OP("*"), new OP("-"), new Token("("), new Token("5"), new OP("+"), new Token("3"), new Token(")"), new Token(")")},
                                Warning = null,
                                Tree =
                                new ExpressionContextTree(new Token("placeholder"))
                                {
                                    Token = null,
                                    Warning = null,
                                    Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                    {

                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new Token("5257.8475"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new OP("*"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("-1"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new OP("*"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = null,
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("5"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                                                                            {

                                                                                                                                                                                                            })
                                                                                                                                                                                                        },


                                                                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new OP("+"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                                                                            {

                                                                                                                                                                                                            })
                                                                                                                                                                                                        },


                                                                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("3"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                                                                            {

                                                                                                                                                                                                            })
                                                                                                                                                                                                        },


                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                })
                                                                                                            },


                                                                        })
                                                                    },


                                    })
                                },

                                BinaryExpression =
                                new BinaryExpression
                                {
                                    Token = null,
                                    Warning = null,
                                    Strength = OPStrength.Power,
                                    StartIndex = 0,
                                    EndIndex = 9,
                                    Inner =
                                                                    new BracketExpression
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Strength = OPStrength.Multiple,
                                                                        StartIndex = 1,
                                                                        EndIndex = 8,
                                                                        Inner =
                                                                                                            new BinaryExpression
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.Multiple,
                                                                                                                StartIndex = 1,
                                                                                                                EndIndex = 1,
                                                                                                                Inner =
                                                                                                                                                        new BinaryExpression
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("5257.8475"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Strength = OPStrength.Multiple,
                                                                                                                                                            StartIndex = 1,
                                                                                                                                                            EndIndex = 1,
                                                                                                                                                            Inner = null,
                                                                                                                                                            Appendix = null
                                                                                                                                                        }
                                                                                                                                                        ,
                                                                                                                Appendix = null
                                                                                                            }
                                                                                                            ,
                                                                        Appendix =
                                                                                                            new AppendixExpression(new OP("*", OPStrength.Multiple, 10), 3, -1)
                                                                                                            {
                                                                                                                Inner =
                                                                                                                                                        new BracketExpression
                                                                                                                                                        {
                                                                                                                                                            Token = null,
                                                                                                                                                            Warning = null,
                                                                                                                                                            Strength = OPStrength.Add,
                                                                                                                                                            StartIndex = 3,
                                                                                                                                                            EndIndex = 7,
                                                                                                                                                            Inner =
                                                                                                                                                                                                        new BinaryExpression
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("-1"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Strength = OPStrength.LogicalOR,
                                                                                                                                                                                                            StartIndex = -1,
                                                                                                                                                                                                            EndIndex = -1,
                                                                                                                                                                                                            Inner = null,
                                                                                                                                                                                                            Appendix = null
                                                                                                                                                                                                        }
                                                                                                                                                                                                        ,
                                                                                                                                                            Appendix =
                                                                                                                                                                                                        new AppendixExpression(new OP("*", OPStrength.Multiple, 12), 4, -1)
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Inner =
                                                                                                                                                                                                                                                            new BracketExpression
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                Token = null,
                                                                                                                                                                                                                                                                Warning = null,
                                                                                                                                                                                                                                                                Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                StartIndex = 5,
                                                                                                                                                                                                                                                                EndIndex = 7,
                                                                                                                                                                                                                                                                Inner =
                                                                                                                                                                                                                                                                                                                    new BinaryExpression
                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                        Token = null,
                                                                                                                                                                                                                                                                                                                        Warning = null,
                                                                                                                                                                                                                                                                                                                        Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                        StartIndex = 5,
                                                                                                                                                                                                                                                                                                                        EndIndex = 5,
                                                                                                                                                                                                                                                                                                                        Inner =
                                                                                                                                                                                                                                                                                                                                                                                new BinaryExpression
                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                    Token = new Token("5"),
                                                                                                                                                                                                                                                                                                                                                                                    Warning = null,
                                                                                                                                                                                                                                                                                                                                                                                    Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                                                                                    StartIndex = 5,
                                                                                                                                                                                                                                                                                                                                                                                    EndIndex = 5,
                                                                                                                                                                                                                                                                                                                                                                                    Inner = null,
                                                                                                                                                                                                                                                                                                                                                                                    Appendix = null
                                                                                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                                                                                                ,
                                                                                                                                                                                                                                                                                                                        Appendix = null
                                                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                                                    ,
                                                                                                                                                                                                                                                                Appendix =
                                                                                                                                                                                                                                                                                                                    new AppendixExpression(new OP("+", OPStrength.Add, 14), 7, -1)
                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                        Inner =
                                                                                                                                                                                                                                                                                                                                                                                new BinaryExpression
                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                    Token = new Token("3"),
                                                                                                                                                                                                                                                                                                                                                                                    Warning = null,
                                                                                                                                                                                                                                                                                                                                                                                    Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                                                                                    StartIndex = 7,
                                                                                                                                                                                                                                                                                                                                                                                    EndIndex = 7,
                                                                                                                                                                                                                                                                                                                                                                                    Inner = null,
                                                                                                                                                                                                                                                                                                                                                                                    Appendix = null
                                                                                                                                                                                                                                                                                                                                                                                }

                                                                                                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                                            }

                                                                                                                                                                                                        }

                                                                                                                                                        }

                                                                                                            }

                                                                    }
                                                                    ,
                                    Appendix = null
                                }


                            }
                        }
                    }
                }
            },
            {
                Tests.Expressions.Expression2, new ExpressionData
                {
                    Culture = new Dictionary<string, ExpressionData.CultureData>
                    {
                        {
                            "cs-CZ",
                            new ExpressionData.CultureData
                            {

                                PrettyPrint = "( 5257,8475 * -5 + 3 )",
                                PrettyPrintWithSeparators = "( 5 257,8475 * -5 + 3 )",
                                ResultString = "-26286.2375",
                                ResultStringWithSeparators = "-26 286,2375",
                                Tokens = new List<Token> {new Token("("), new Token("5257.8475"), new OP("*"), new Token("-5"), new OP("+"), new Token("3"), new Token(")")},
                                Warning = null,
                                Tree =
                                new ExpressionContextTree(new Token("placeholder"))
                                {
                                    Token = null,
                                    Warning = null,
                                    Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                    {

                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("5257.8475"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new OP("*"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("-5"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new OP("+"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new Token("3"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                        })
                                                                    },


                                    })
                                },

                                BinaryExpression =
                                new BinaryExpression
                                {
                                    Token = null,
                                    Warning = null,
                                    Strength = OPStrength.Power,
                                    StartIndex = 0,
                                    EndIndex = 6,
                                    Inner =
                                                                    new BracketExpression
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Strength = OPStrength.Add,
                                                                        StartIndex = 1,
                                                                        EndIndex = 5,
                                                                        Inner =
                                                                                                            new BinaryExpression
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.Multiple,
                                                                                                                StartIndex = 1,
                                                                                                                EndIndex = 3,
                                                                                                                Inner =
                                                                                                                                                        new BinaryExpression
                                                                                                                                                        {
                                                                                                                                                            Token = null,
                                                                                                                                                            Warning = null,
                                                                                                                                                            Strength = OPStrength.Multiple,
                                                                                                                                                            StartIndex = 1,
                                                                                                                                                            EndIndex = 1,
                                                                                                                                                            Inner =
                                                                                                                                                                                                        new BinaryExpression
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("5257.8475"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Strength = OPStrength.Multiple,
                                                                                                                                                                                                            StartIndex = 1,
                                                                                                                                                                                                            EndIndex = 1,
                                                                                                                                                                                                            Inner = null,
                                                                                                                                                                                                            Appendix = null
                                                                                                                                                                                                        }
                                                                                                                                                                                                        ,
                                                                                                                                                            Appendix = null
                                                                                                                                                        }
                                                                                                                                                        ,
                                                                                                                Appendix =
                                                                                                                                                        new AppendixExpression(new OP("*", OPStrength.Multiple, 11), 3, -1)
                                                                                                                                                        {
                                                                                                                                                            Inner =
                                                                                                                                                                                                        new BinaryExpression
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("-5"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Strength = OPStrength.Multiple,
                                                                                                                                                                                                            StartIndex = 3,
                                                                                                                                                                                                            EndIndex = 3,
                                                                                                                                                                                                            Inner = null,
                                                                                                                                                                                                            Appendix = null
                                                                                                                                                                                                        }

                                                                                                                                                        }

                                                                                                            }
                                                                                                            ,
                                                                        Appendix =
                                                                                                            new AppendixExpression(new OP("+", OPStrength.Add, 15), 5, -1)
                                                                                                            {
                                                                                                                Inner =
                                                                                                                                                        new BinaryExpression
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("3"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Strength = OPStrength.Add,
                                                                                                                                                            StartIndex = 5,
                                                                                                                                                            EndIndex = 5,
                                                                                                                                                            Inner = null,
                                                                                                                                                            Appendix = null
                                                                                                                                                        }

                                                                                                            }

                                                                    }
                                                                    ,
                                    Appendix = null
                                }


                            }
                        },
                        {
                            "en-US",
                            new ExpressionData.CultureData
                            {

                                PrettyPrint = "( 5257.8475 * -5 + 3 )",
                                PrettyPrintWithSeparators = "( 5,257.8475 * -5 + 3 )",
                                ResultString = "-26286.2375",
                                ResultStringWithSeparators = "-26,286.2375",
                                Tokens = new List<Token> {new Token("("), new Token("5257.8475"), new OP("*"), new Token("-5"), new OP("+"), new Token("3"), new Token(")")},
                                Warning = null,
                                Tree =
                                new ExpressionContextTree(new Token("placeholder"))
                                {
                                    Token = null,
                                    Warning = null,
                                    Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                    {

                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("5257.8475"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new OP("*"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("-5"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new OP("+"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new Token("3"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                        })
                                                                    },


                                    })
                                },

                                BinaryExpression =
                                new BinaryExpression
                                {
                                    Token = null,
                                    Warning = null,
                                    Strength = OPStrength.Power,
                                    StartIndex = 0,
                                    EndIndex = 6,
                                    Inner =
                                                                    new BracketExpression
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Strength = OPStrength.Add,
                                                                        StartIndex = 1,
                                                                        EndIndex = 5,
                                                                        Inner =
                                                                                                            new BinaryExpression
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.Multiple,
                                                                                                                StartIndex = 1,
                                                                                                                EndIndex = 3,
                                                                                                                Inner =
                                                                                                                                                        new BinaryExpression
                                                                                                                                                        {
                                                                                                                                                            Token = null,
                                                                                                                                                            Warning = null,
                                                                                                                                                            Strength = OPStrength.Multiple,
                                                                                                                                                            StartIndex = 1,
                                                                                                                                                            EndIndex = 1,
                                                                                                                                                            Inner =
                                                                                                                                                                                                        new BinaryExpression
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("5257.8475"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Strength = OPStrength.Multiple,
                                                                                                                                                                                                            StartIndex = 1,
                                                                                                                                                                                                            EndIndex = 1,
                                                                                                                                                                                                            Inner = null,
                                                                                                                                                                                                            Appendix = null
                                                                                                                                                                                                        }
                                                                                                                                                                                                        ,
                                                                                                                                                            Appendix = null
                                                                                                                                                        }
                                                                                                                                                        ,
                                                                                                                Appendix =
                                                                                                                                                        new AppendixExpression(new OP("*", OPStrength.Multiple, 11), 3, -1)
                                                                                                                                                        {
                                                                                                                                                            Inner =
                                                                                                                                                                                                        new BinaryExpression
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("-5"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Strength = OPStrength.Multiple,
                                                                                                                                                                                                            StartIndex = 3,
                                                                                                                                                                                                            EndIndex = 3,
                                                                                                                                                                                                            Inner = null,
                                                                                                                                                                                                            Appendix = null
                                                                                                                                                                                                        }

                                                                                                                                                        }

                                                                                                            }
                                                                                                            ,
                                                                        Appendix =
                                                                                                            new AppendixExpression(new OP("+", OPStrength.Add, 15), 5, -1)
                                                                                                            {
                                                                                                                Inner =
                                                                                                                                                        new BinaryExpression
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("3"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Strength = OPStrength.Add,
                                                                                                                                                            StartIndex = 5,
                                                                                                                                                            EndIndex = 5,
                                                                                                                                                            Inner = null,
                                                                                                                                                            Appendix = null
                                                                                                                                                        }

                                                                                                            }

                                                                    }
                                                                    ,
                                    Appendix = null
                                }


                            }
                        }
                    }
                }
            },
            {
                Tests.Expressions.Expression3, new ExpressionData
                {
                    Culture = new Dictionary<string, ExpressionData.CultureData>
                    {
                        {
                            "cs-CZ",
                            new ExpressionData.CultureData
                            {

                                PrettyPrint = "5257,8475 * -( 5 + 3 ) & 3483",
                                PrettyPrintWithSeparators = "5 257,8475 * -( 5 + 3 ) & 3 483",
                                ResultString = "2450",
                                ResultStringWithSeparators = "2 450",
                                Tokens = new List<Token> {new Token("5257.8475"), new OP("*"), new OP("-"), new Token("("), new Token("5"), new OP("+"), new Token("3"), new Token(")"), new OP("&"), new Token("3483")},
                                Warning = null,
                                Tree =
                                new ExpressionContextTree(new Token("placeholder"))
                                {
                                    Token = null,
                                    Warning = null,
                                    Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                    {

                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new Token("5257.8475"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new OP("*"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("-1"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new OP("*"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = null,
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("5"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                                                                            {

                                                                                                                                                                                                            })
                                                                                                                                                                                                        },


                                                                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new OP("+"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                                                                            {

                                                                                                                                                                                                            })
                                                                                                                                                                                                        },


                                                                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("3"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                                                                            {

                                                                                                                                                                                                            })
                                                                                                                                                                                                        },


                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                })
                                                                                                            },


                                                                        })
                                                                    },


                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = new OP("&"),
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                        })
                                                                    },


                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = new Token("3483"),
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                        })
                                                                    },


                                    })
                                },

                                BinaryExpression =
                                new BinaryExpression
                                {
                                    Token = null,
                                    Warning = null,
                                    Strength = OPStrength.LogicalAnd,
                                    StartIndex = 0,
                                    EndIndex = 9,
                                    Inner =
                                                                    new BinaryExpression
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Strength = OPStrength.Multiple,
                                                                        StartIndex = 0,
                                                                        EndIndex = 7,
                                                                        Inner =
                                                                                                            new BinaryExpression
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.Multiple,
                                                                                                                StartIndex = 0,
                                                                                                                EndIndex = 0,
                                                                                                                Inner =
                                                                                                                                                        new BinaryExpression
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("5257.8475"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Strength = OPStrength.Multiple,
                                                                                                                                                            StartIndex = 0,
                                                                                                                                                            EndIndex = 0,
                                                                                                                                                            Inner = null,
                                                                                                                                                            Appendix = null
                                                                                                                                                        }
                                                                                                                                                        ,
                                                                                                                Appendix = null
                                                                                                            }
                                                                                                            ,
                                                                        Appendix =
                                                                                                            new AppendixExpression(new OP("*", OPStrength.Multiple, 9), 2, -1)
                                                                                                            {
                                                                                                                Inner =
                                                                                                                                                        new BracketExpression
                                                                                                                                                        {
                                                                                                                                                            Token = null,
                                                                                                                                                            Warning = null,
                                                                                                                                                            Strength = OPStrength.Add,
                                                                                                                                                            StartIndex = 2,
                                                                                                                                                            EndIndex = 6,
                                                                                                                                                            Inner =
                                                                                                                                                                                                        new BinaryExpression
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("-1"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Strength = OPStrength.LogicalOR,
                                                                                                                                                                                                            StartIndex = -1,
                                                                                                                                                                                                            EndIndex = -1,
                                                                                                                                                                                                            Inner = null,
                                                                                                                                                                                                            Appendix = null
                                                                                                                                                                                                        }
                                                                                                                                                                                                        ,
                                                                                                                                                            Appendix =
                                                                                                                                                                                                        new AppendixExpression(new OP("*", OPStrength.Multiple, 11), 3, -1)
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Inner =
                                                                                                                                                                                                                                                            new BracketExpression
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                Token = null,
                                                                                                                                                                                                                                                                Warning = null,
                                                                                                                                                                                                                                                                Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                StartIndex = 4,
                                                                                                                                                                                                                                                                EndIndex = 6,
                                                                                                                                                                                                                                                                Inner =
                                                                                                                                                                                                                                                                                                                    new BinaryExpression
                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                        Token = null,
                                                                                                                                                                                                                                                                                                                        Warning = null,
                                                                                                                                                                                                                                                                                                                        Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                        StartIndex = 4,
                                                                                                                                                                                                                                                                                                                        EndIndex = 4,
                                                                                                                                                                                                                                                                                                                        Inner =
                                                                                                                                                                                                                                                                                                                                                                                new BinaryExpression
                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                    Token = new Token("5"),
                                                                                                                                                                                                                                                                                                                                                                                    Warning = null,
                                                                                                                                                                                                                                                                                                                                                                                    Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                                                                                    StartIndex = 4,
                                                                                                                                                                                                                                                                                                                                                                                    EndIndex = 4,
                                                                                                                                                                                                                                                                                                                                                                                    Inner = null,
                                                                                                                                                                                                                                                                                                                                                                                    Appendix = null
                                                                                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                                                                                                ,
                                                                                                                                                                                                                                                                                                                        Appendix = null
                                                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                                                    ,
                                                                                                                                                                                                                                                                Appendix =
                                                                                                                                                                                                                                                                                                                    new AppendixExpression(new OP("+", OPStrength.Add, 13), 6, -1)
                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                        Inner =
                                                                                                                                                                                                                                                                                                                                                                                new BinaryExpression
                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                    Token = new Token("3"),
                                                                                                                                                                                                                                                                                                                                                                                    Warning = null,
                                                                                                                                                                                                                                                                                                                                                                                    Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                                                                                    StartIndex = 6,
                                                                                                                                                                                                                                                                                                                                                                                    EndIndex = 6,
                                                                                                                                                                                                                                                                                                                                                                                    Inner = null,
                                                                                                                                                                                                                                                                                                                                                                                    Appendix = null
                                                                                                                                                                                                                                                                                                                                                                                }

                                                                                                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                                            }

                                                                                                                                                                                                        }

                                                                                                                                                        }

                                                                                                            }

                                                                    }
                                                                    ,
                                    Appendix =
                                                                    new AppendixExpression(new OP("&", OPStrength.LogicalAnd, 17), 9, -1)
                                                                    {
                                                                        Inner =
                                                                                                            new BinaryExpression
                                                                                                            {
                                                                                                                Token = new Token("3483"),
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.LogicalAnd,
                                                                                                                StartIndex = 9,
                                                                                                                EndIndex = 9,
                                                                                                                Inner = null,
                                                                                                                Appendix = null
                                                                                                            }

                                                                    }

                                }


                            }
                        },
                        {
                            "en-US",
                            new ExpressionData.CultureData
                            {

                                PrettyPrint = "5257.8475 * -( 5 + 3 ) & 3483",
                                PrettyPrintWithSeparators = "5,257.8475 * -( 5 + 3 ) & 3,483",
                                ResultString = "2450",
                                ResultStringWithSeparators = "2,450",
                                Tokens = new List<Token> {new Token("5257.8475"), new OP("*"), new OP("-"), new Token("("), new Token("5"), new OP("+"), new Token("3"), new Token(")"), new OP("&"), new Token("3483")},
                                Warning = null,
                                Tree =
                                new ExpressionContextTree(new Token("placeholder"))
                                {
                                    Token = null,
                                    Warning = null,
                                    Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                    {

                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new Token("5257.8475"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new OP("*"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("-1"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new OP("*"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = null,
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("5"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                                                                            {

                                                                                                                                                                                                            })
                                                                                                                                                                                                        },


                                                                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new OP("+"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                                                                            {

                                                                                                                                                                                                            })
                                                                                                                                                                                                        },


                                                                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("3"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                                                                            {

                                                                                                                                                                                                            })
                                                                                                                                                                                                        },


                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                })
                                                                                                            },


                                                                        })
                                                                    },


                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = new OP("&"),
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                        })
                                                                    },


                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = new Token("3483"),
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                        })
                                                                    },


                                    })
                                },

                                BinaryExpression =
                                new BinaryExpression
                                {
                                    Token = null,
                                    Warning = null,
                                    Strength = OPStrength.LogicalAnd,
                                    StartIndex = 0,
                                    EndIndex = 9,
                                    Inner =
                                                                    new BinaryExpression
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Strength = OPStrength.Multiple,
                                                                        StartIndex = 0,
                                                                        EndIndex = 7,
                                                                        Inner =
                                                                                                            new BinaryExpression
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.Multiple,
                                                                                                                StartIndex = 0,
                                                                                                                EndIndex = 0,
                                                                                                                Inner =
                                                                                                                                                        new BinaryExpression
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("5257.8475"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Strength = OPStrength.Multiple,
                                                                                                                                                            StartIndex = 0,
                                                                                                                                                            EndIndex = 0,
                                                                                                                                                            Inner = null,
                                                                                                                                                            Appendix = null
                                                                                                                                                        }
                                                                                                                                                        ,
                                                                                                                Appendix = null
                                                                                                            }
                                                                                                            ,
                                                                        Appendix =
                                                                                                            new AppendixExpression(new OP("*", OPStrength.Multiple, 9), 2, -1)
                                                                                                            {
                                                                                                                Inner =
                                                                                                                                                        new BracketExpression
                                                                                                                                                        {
                                                                                                                                                            Token = null,
                                                                                                                                                            Warning = null,
                                                                                                                                                            Strength = OPStrength.Add,
                                                                                                                                                            StartIndex = 2,
                                                                                                                                                            EndIndex = 6,
                                                                                                                                                            Inner =
                                                                                                                                                                                                        new BinaryExpression
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("-1"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Strength = OPStrength.LogicalOR,
                                                                                                                                                                                                            StartIndex = -1,
                                                                                                                                                                                                            EndIndex = -1,
                                                                                                                                                                                                            Inner = null,
                                                                                                                                                                                                            Appendix = null
                                                                                                                                                                                                        }
                                                                                                                                                                                                        ,
                                                                                                                                                            Appendix =
                                                                                                                                                                                                        new AppendixExpression(new OP("*", OPStrength.Multiple, 11), 3, -1)
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Inner =
                                                                                                                                                                                                                                                            new BracketExpression
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                Token = null,
                                                                                                                                                                                                                                                                Warning = null,
                                                                                                                                                                                                                                                                Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                StartIndex = 4,
                                                                                                                                                                                                                                                                EndIndex = 6,
                                                                                                                                                                                                                                                                Inner =
                                                                                                                                                                                                                                                                                                                    new BinaryExpression
                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                        Token = null,
                                                                                                                                                                                                                                                                                                                        Warning = null,
                                                                                                                                                                                                                                                                                                                        Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                        StartIndex = 4,
                                                                                                                                                                                                                                                                                                                        EndIndex = 4,
                                                                                                                                                                                                                                                                                                                        Inner =
                                                                                                                                                                                                                                                                                                                                                                                new BinaryExpression
                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                    Token = new Token("5"),
                                                                                                                                                                                                                                                                                                                                                                                    Warning = null,
                                                                                                                                                                                                                                                                                                                                                                                    Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                                                                                    StartIndex = 4,
                                                                                                                                                                                                                                                                                                                                                                                    EndIndex = 4,
                                                                                                                                                                                                                                                                                                                                                                                    Inner = null,
                                                                                                                                                                                                                                                                                                                                                                                    Appendix = null
                                                                                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                                                                                                ,
                                                                                                                                                                                                                                                                                                                        Appendix = null
                                                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                                                    ,
                                                                                                                                                                                                                                                                Appendix =
                                                                                                                                                                                                                                                                                                                    new AppendixExpression(new OP("+", OPStrength.Add, 13), 6, -1)
                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                        Inner =
                                                                                                                                                                                                                                                                                                                                                                                new BinaryExpression
                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                    Token = new Token("3"),
                                                                                                                                                                                                                                                                                                                                                                                    Warning = null,
                                                                                                                                                                                                                                                                                                                                                                                    Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                                                                                    StartIndex = 6,
                                                                                                                                                                                                                                                                                                                                                                                    EndIndex = 6,
                                                                                                                                                                                                                                                                                                                                                                                    Inner = null,
                                                                                                                                                                                                                                                                                                                                                                                    Appendix = null
                                                                                                                                                                                                                                                                                                                                                                                }

                                                                                                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                                            }

                                                                                                                                                                                                        }

                                                                                                                                                        }

                                                                                                            }

                                                                    }
                                                                    ,
                                    Appendix =
                                                                    new AppendixExpression(new OP("&", OPStrength.LogicalAnd, 17), 9, -1)
                                                                    {
                                                                        Inner =
                                                                                                            new BinaryExpression
                                                                                                            {
                                                                                                                Token = new Token("3483"),
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.LogicalAnd,
                                                                                                                StartIndex = 9,
                                                                                                                EndIndex = 9,
                                                                                                                Inner = null,
                                                                                                                Appendix = null
                                                                                                            }

                                                                    }

                                }


                            }
                        }
                    }
                }
            },
            {
                Tests.Expressions.Expression4, new ExpressionData
                {
                    Culture = new Dictionary<string, ExpressionData.CultureData>
                    {
                        {
                            "cs-CZ",
                            new ExpressionData.CultureData
                            {

                                PrettyPrint = "( 5257,8475 * -( 5 + 3 ) ) < 0",
                                PrettyPrintWithSeparators = "( 5 257,8475 * -( 5 + 3 ) ) < 0",
                                ResultString = "1",
                                ResultStringWithSeparators = "1",
                                Tokens = new List<Token> {new Token("("), new Token("5257.8475"), new OP("*"), new OP("-"), new Token("("), new Token("5"), new OP("+"), new Token("3"), new Token(")"), new Token(")"), new OP("<"), new Token("0")},
                                Warning = null,
                                Tree =
                                new ExpressionContextTree(new Token("placeholder"))
                                {
                                    Token = null,
                                    Warning = null,
                                    Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                    {

                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new Token("5257.8475"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new OP("*"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("-1"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new OP("*"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = null,
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("5"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                                                                            {

                                                                                                                                                                                                            })
                                                                                                                                                                                                        },


                                                                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new OP("+"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                                                                            {

                                                                                                                                                                                                            })
                                                                                                                                                                                                        },


                                                                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("3"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                                                                            {

                                                                                                                                                                                                            })
                                                                                                                                                                                                        },


                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                })
                                                                                                            },


                                                                        })
                                                                    },


                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = new OP("<"),
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                        })
                                                                    },


                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = new Token("0"),
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                        })
                                                                    },


                                    })
                                },

                                BinaryExpression =
                                new BinaryExpression
                                {
                                    Token = null,
                                    Warning = null,
                                    Strength = OPStrength.Comparison,
                                    StartIndex = 0,
                                    EndIndex = 11,
                                    Inner =
                                                                    new BinaryExpression
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Strength = OPStrength.Comparison,
                                                                        StartIndex = 0,
                                                                        EndIndex = 9,
                                                                        Inner =
                                                                                                            new BracketExpression
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.Multiple,
                                                                                                                StartIndex = 1,
                                                                                                                EndIndex = 8,
                                                                                                                Inner =
                                                                                                                                                        new BinaryExpression
                                                                                                                                                        {
                                                                                                                                                            Token = null,
                                                                                                                                                            Warning = null,
                                                                                                                                                            Strength = OPStrength.Multiple,
                                                                                                                                                            StartIndex = 1,
                                                                                                                                                            EndIndex = 1,
                                                                                                                                                            Inner =
                                                                                                                                                                                                        new BinaryExpression
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("5257.8475"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Strength = OPStrength.Multiple,
                                                                                                                                                                                                            StartIndex = 1,
                                                                                                                                                                                                            EndIndex = 1,
                                                                                                                                                                                                            Inner = null,
                                                                                                                                                                                                            Appendix = null
                                                                                                                                                                                                        }
                                                                                                                                                                                                        ,
                                                                                                                                                            Appendix = null
                                                                                                                                                        }
                                                                                                                                                        ,
                                                                                                                Appendix =
                                                                                                                                                        new AppendixExpression(new OP("*", OPStrength.Multiple, 10), 3, -1)
                                                                                                                                                        {
                                                                                                                                                            Inner =
                                                                                                                                                                                                        new BracketExpression
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = null,
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Strength = OPStrength.Add,
                                                                                                                                                                                                            StartIndex = 3,
                                                                                                                                                                                                            EndIndex = 7,
                                                                                                                                                                                                            Inner =
                                                                                                                                                                                                                                                            new BinaryExpression
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                Token = new Token("-1"),
                                                                                                                                                                                                                                                                Warning = null,
                                                                                                                                                                                                                                                                Strength = OPStrength.LogicalOR,
                                                                                                                                                                                                                                                                StartIndex = -1,
                                                                                                                                                                                                                                                                EndIndex = -1,
                                                                                                                                                                                                                                                                Inner = null,
                                                                                                                                                                                                                                                                Appendix = null
                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                            ,
                                                                                                                                                                                                            Appendix =
                                                                                                                                                                                                                                                            new AppendixExpression(new OP("*", OPStrength.Multiple, 13), 4, -1)
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                Inner =
                                                                                                                                                                                                                                                                                                                    new BracketExpression
                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                        Token = null,
                                                                                                                                                                                                                                                                                                                        Warning = null,
                                                                                                                                                                                                                                                                                                                        Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                        StartIndex = 5,
                                                                                                                                                                                                                                                                                                                        EndIndex = 7,
                                                                                                                                                                                                                                                                                                                        Inner =
                                                                                                                                                                                                                                                                                                                                                                                new BinaryExpression
                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                    Token = null,
                                                                                                                                                                                                                                                                                                                                                                                    Warning = null,
                                                                                                                                                                                                                                                                                                                                                                                    Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                                                                                    StartIndex = 5,
                                                                                                                                                                                                                                                                                                                                                                                    EndIndex = 5,
                                                                                                                                                                                                                                                                                                                                                                                    Inner =
                                                                                                                                                                                                                                                                                                                                                                                                                                                new BinaryExpression
                                                                                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Token = new Token("5"),
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Warning = null,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    StartIndex = 5,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    EndIndex = 5,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Inner = null,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Appendix = null
                                                                                                                                                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                                                                                                                                                                ,
                                                                                                                                                                                                                                                                                                                                                                                    Appendix = null
                                                                                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                                                                                                ,
                                                                                                                                                                                                                                                                                                                        Appendix =
                                                                                                                                                                                                                                                                                                                                                                                new AppendixExpression(new OP("+", OPStrength.Add, 15), 7, -1)
                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                    Inner =
                                                                                                                                                                                                                                                                                                                                                                                                                                                new BinaryExpression
                                                                                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Token = new Token("3"),
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Warning = null,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    StartIndex = 7,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    EndIndex = 7,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Inner = null,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Appendix = null
                                                                                                                                                                                                                                                                                                                                                                                                                                                }

                                                                                                                                                                                                                                                                                                                                                                                }

                                                                                                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                                            }

                                                                                                                                                                                                        }

                                                                                                                                                        }

                                                                                                            }
                                                                                                            ,
                                                                        Appendix = null
                                                                    }
                                                                    ,
                                    Appendix =
                                                                    new AppendixExpression(new OP("<", OPStrength.Comparison, 20), 11, -1)
                                                                    {
                                                                        Inner =
                                                                                                            new BinaryExpression
                                                                                                            {
                                                                                                                Token = new Token("0"),
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.Comparison,
                                                                                                                StartIndex = 11,
                                                                                                                EndIndex = 11,
                                                                                                                Inner = null,
                                                                                                                Appendix = null
                                                                                                            }

                                                                    }

                                }


                            }
                        },
                        {
                            "en-US",
                            new ExpressionData.CultureData
                            {

                                PrettyPrint = "( 5257.8475 * -( 5 + 3 ) ) < 0",
                                PrettyPrintWithSeparators = "( 5,257.8475 * -( 5 + 3 ) ) < 0",
                                ResultString = "1",
                                ResultStringWithSeparators = "1",
                                Tokens = new List<Token> {new Token("("), new Token("5257.8475"), new OP("*"), new OP("-"), new Token("("), new Token("5"), new OP("+"), new Token("3"), new Token(")"), new Token(")"), new OP("<"), new Token("0")},
                                Warning = null,
                                Tree =
                                new ExpressionContextTree(new Token("placeholder"))
                                {
                                    Token = null,
                                    Warning = null,
                                    Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                    {

                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new Token("5257.8475"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new OP("*"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("-1"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new OP("*"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = null,
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("5"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                                                                            {

                                                                                                                                                                                                            })
                                                                                                                                                                                                        },


                                                                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new OP("+"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                                                                            {

                                                                                                                                                                                                            })
                                                                                                                                                                                                        },


                                                                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("3"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                                                                            {

                                                                                                                                                                                                            })
                                                                                                                                                                                                        },


                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                })
                                                                                                            },


                                                                        })
                                                                    },


                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = new OP("<"),
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                        })
                                                                    },


                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = new Token("0"),
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                        })
                                                                    },


                                    })
                                },

                                BinaryExpression =
                                new BinaryExpression
                                {
                                    Token = null,
                                    Warning = null,
                                    Strength = OPStrength.Comparison,
                                    StartIndex = 0,
                                    EndIndex = 11,
                                    Inner =
                                                                    new BinaryExpression
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Strength = OPStrength.Comparison,
                                                                        StartIndex = 0,
                                                                        EndIndex = 9,
                                                                        Inner =
                                                                                                            new BracketExpression
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.Multiple,
                                                                                                                StartIndex = 1,
                                                                                                                EndIndex = 8,
                                                                                                                Inner =
                                                                                                                                                        new BinaryExpression
                                                                                                                                                        {
                                                                                                                                                            Token = null,
                                                                                                                                                            Warning = null,
                                                                                                                                                            Strength = OPStrength.Multiple,
                                                                                                                                                            StartIndex = 1,
                                                                                                                                                            EndIndex = 1,
                                                                                                                                                            Inner =
                                                                                                                                                                                                        new BinaryExpression
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("5257.8475"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Strength = OPStrength.Multiple,
                                                                                                                                                                                                            StartIndex = 1,
                                                                                                                                                                                                            EndIndex = 1,
                                                                                                                                                                                                            Inner = null,
                                                                                                                                                                                                            Appendix = null
                                                                                                                                                                                                        }
                                                                                                                                                                                                        ,
                                                                                                                                                            Appendix = null
                                                                                                                                                        }
                                                                                                                                                        ,
                                                                                                                Appendix =
                                                                                                                                                        new AppendixExpression(new OP("*", OPStrength.Multiple, 10), 3, -1)
                                                                                                                                                        {
                                                                                                                                                            Inner =
                                                                                                                                                                                                        new BracketExpression
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = null,
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Strength = OPStrength.Add,
                                                                                                                                                                                                            StartIndex = 3,
                                                                                                                                                                                                            EndIndex = 7,
                                                                                                                                                                                                            Inner =
                                                                                                                                                                                                                                                            new BinaryExpression
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                Token = new Token("-1"),
                                                                                                                                                                                                                                                                Warning = null,
                                                                                                                                                                                                                                                                Strength = OPStrength.LogicalOR,
                                                                                                                                                                                                                                                                StartIndex = -1,
                                                                                                                                                                                                                                                                EndIndex = -1,
                                                                                                                                                                                                                                                                Inner = null,
                                                                                                                                                                                                                                                                Appendix = null
                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                            ,
                                                                                                                                                                                                            Appendix =
                                                                                                                                                                                                                                                            new AppendixExpression(new OP("*", OPStrength.Multiple, 13), 4, -1)
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                Inner =
                                                                                                                                                                                                                                                                                                                    new BracketExpression
                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                        Token = null,
                                                                                                                                                                                                                                                                                                                        Warning = null,
                                                                                                                                                                                                                                                                                                                        Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                        StartIndex = 5,
                                                                                                                                                                                                                                                                                                                        EndIndex = 7,
                                                                                                                                                                                                                                                                                                                        Inner =
                                                                                                                                                                                                                                                                                                                                                                                new BinaryExpression
                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                    Token = null,
                                                                                                                                                                                                                                                                                                                                                                                    Warning = null,
                                                                                                                                                                                                                                                                                                                                                                                    Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                                                                                    StartIndex = 5,
                                                                                                                                                                                                                                                                                                                                                                                    EndIndex = 5,
                                                                                                                                                                                                                                                                                                                                                                                    Inner =
                                                                                                                                                                                                                                                                                                                                                                                                                                                new BinaryExpression
                                                                                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Token = new Token("5"),
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Warning = null,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    StartIndex = 5,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    EndIndex = 5,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Inner = null,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Appendix = null
                                                                                                                                                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                                                                                                                                                                ,
                                                                                                                                                                                                                                                                                                                                                                                    Appendix = null
                                                                                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                                                                                                ,
                                                                                                                                                                                                                                                                                                                        Appendix =
                                                                                                                                                                                                                                                                                                                                                                                new AppendixExpression(new OP("+", OPStrength.Add, 15), 7, -1)
                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                    Inner =
                                                                                                                                                                                                                                                                                                                                                                                                                                                new BinaryExpression
                                                                                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Token = new Token("3"),
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Warning = null,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Strength = OPStrength.Add,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    StartIndex = 7,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    EndIndex = 7,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Inner = null,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    Appendix = null
                                                                                                                                                                                                                                                                                                                                                                                                                                                }

                                                                                                                                                                                                                                                                                                                                                                                }

                                                                                                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                                            }

                                                                                                                                                                                                        }

                                                                                                                                                        }

                                                                                                            }
                                                                                                            ,
                                                                        Appendix = null
                                                                    }
                                                                    ,
                                    Appendix =
                                                                    new AppendixExpression(new OP("<", OPStrength.Comparison, 20), 11, -1)
                                                                    {
                                                                        Inner =
                                                                                                            new BinaryExpression
                                                                                                            {
                                                                                                                Token = new Token("0"),
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.Comparison,
                                                                                                                StartIndex = 11,
                                                                                                                EndIndex = 11,
                                                                                                                Inner = null,
                                                                                                                Appendix = null
                                                                                                            }

                                                                    }

                                }


                            }
                        }
                    }
                }
            },
            {
                Tests.Expressions.Expression5, new ExpressionData
                {
                    Culture = new Dictionary<string, ExpressionData.CultureData>
                    {
                        {
                            "cs-CZ",
                            new ExpressionData.CultureData
                            {

                                PrettyPrint = "( 5257,8475 * -5 + 3 ) > 0",
                                PrettyPrintWithSeparators = "( 5 257,8475 * -5 + 3 ) > 0",
                                ResultString = "0",
                                ResultStringWithSeparators = "0",
                                Tokens = new List<Token> {new Token("("), new Token("5257.8475"), new OP("*"), new Token("-5"), new OP("+"), new Token("3"), new Token(")"), new OP(">"), new Token("0")},
                                Warning = null,
                                Tree =
                                new ExpressionContextTree(new Token("placeholder"))
                                {
                                    Token = null,
                                    Warning = null,
                                    Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                    {

                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("5257.8475"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new OP("*"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("-5"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new OP("+"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new Token("3"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                        })
                                                                    },


                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = new OP(">"),
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                        })
                                                                    },


                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = new Token("0"),
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                        })
                                                                    },


                                    })
                                },

                                BinaryExpression =
                                new BinaryExpression
                                {
                                    Token = null,
                                    Warning = null,
                                    Strength = OPStrength.Comparison,
                                    StartIndex = 0,
                                    EndIndex = 8,
                                    Inner =
                                                                    new BinaryExpression
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Strength = OPStrength.Comparison,
                                                                        StartIndex = 0,
                                                                        EndIndex = 6,
                                                                        Inner =
                                                                                                            new BracketExpression
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.Add,
                                                                                                                StartIndex = 1,
                                                                                                                EndIndex = 5,
                                                                                                                Inner =
                                                                                                                                                        new BinaryExpression
                                                                                                                                                        {
                                                                                                                                                            Token = null,
                                                                                                                                                            Warning = null,
                                                                                                                                                            Strength = OPStrength.Multiple,
                                                                                                                                                            StartIndex = 1,
                                                                                                                                                            EndIndex = 3,
                                                                                                                                                            Inner =
                                                                                                                                                                                                        new BinaryExpression
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = null,
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Strength = OPStrength.Multiple,
                                                                                                                                                                                                            StartIndex = 1,
                                                                                                                                                                                                            EndIndex = 1,
                                                                                                                                                                                                            Inner =
                                                                                                                                                                                                                                                            new BinaryExpression
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                Token = new Token("5257.8475"),
                                                                                                                                                                                                                                                                Warning = null,
                                                                                                                                                                                                                                                                Strength = OPStrength.Multiple,
                                                                                                                                                                                                                                                                StartIndex = 1,
                                                                                                                                                                                                                                                                EndIndex = 1,
                                                                                                                                                                                                                                                                Inner = null,
                                                                                                                                                                                                                                                                Appendix = null
                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                            ,
                                                                                                                                                                                                            Appendix = null
                                                                                                                                                                                                        }
                                                                                                                                                                                                        ,
                                                                                                                                                            Appendix =
                                                                                                                                                                                                        new AppendixExpression(new OP("*", OPStrength.Multiple, 11), 3, -1)
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Inner =
                                                                                                                                                                                                                                                            new BinaryExpression
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                Token = new Token("-5"),
                                                                                                                                                                                                                                                                Warning = null,
                                                                                                                                                                                                                                                                Strength = OPStrength.Multiple,
                                                                                                                                                                                                                                                                StartIndex = 3,
                                                                                                                                                                                                                                                                EndIndex = 3,
                                                                                                                                                                                                                                                                Inner = null,
                                                                                                                                                                                                                                                                Appendix = null
                                                                                                                                                                                                                                                            }

                                                                                                                                                                                                        }

                                                                                                                                                        }
                                                                                                                                                        ,
                                                                                                                Appendix =
                                                                                                                                                        new AppendixExpression(new OP("+", OPStrength.Add, 14), 5, -1)
                                                                                                                                                        {
                                                                                                                                                            Inner =
                                                                                                                                                                                                        new BinaryExpression
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("3"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Strength = OPStrength.Add,
                                                                                                                                                                                                            StartIndex = 5,
                                                                                                                                                                                                            EndIndex = 5,
                                                                                                                                                                                                            Inner = null,
                                                                                                                                                                                                            Appendix = null
                                                                                                                                                                                                        }

                                                                                                                                                        }

                                                                                                            }
                                                                                                            ,
                                                                        Appendix = null
                                                                    }
                                                                    ,
                                    Appendix =
                                                                    new AppendixExpression(new OP(">", OPStrength.Comparison, 18), 8, -1)
                                                                    {
                                                                        Inner =
                                                                                                            new BinaryExpression
                                                                                                            {
                                                                                                                Token = new Token("0"),
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.Comparison,
                                                                                                                StartIndex = 8,
                                                                                                                EndIndex = 8,
                                                                                                                Inner = null,
                                                                                                                Appendix = null
                                                                                                            }

                                                                    }

                                }


                            }
                        },
                        {
                            "en-US",
                            new ExpressionData.CultureData
                            {

                                PrettyPrint = "( 5257.8475 * -5 + 3 ) > 0",
                                PrettyPrintWithSeparators = "( 5,257.8475 * -5 + 3 ) > 0",
                                ResultString = "0",
                                ResultStringWithSeparators = "0",
                                Tokens = new List<Token> {new Token("("), new Token("5257.8475"), new OP("*"), new Token("-5"), new OP("+"), new Token("3"), new Token(")"), new OP(">"), new Token("0")},
                                Warning = null,
                                Tree =
                                new ExpressionContextTree(new Token("placeholder"))
                                {
                                    Token = null,
                                    Warning = null,
                                    Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                    {

                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("5257.8475"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new OP("*"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                                                        new ExpressionContextTree(new Token("placeholder"))
                                                                                                                                                        {
                                                                                                                                                            Token = new Token("-5"),
                                                                                                                                                            Warning = null,
                                                                                                                                                            Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                                                            {

                                                                                                                                                            })
                                                                                                                                                        },


                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new OP("+"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                                                            new ExpressionContextTree(new Token("placeholder"))
                                                                                                            {
                                                                                                                Token = new Token("3"),
                                                                                                                Warning = null,
                                                                                                                Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                                                                {

                                                                                                                })
                                                                                                            },


                                                                        })
                                                                    },


                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = new OP(">"),
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                        })
                                                                    },


                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = new Token("0"),
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                        })
                                                                    },


                                    })
                                },

                                BinaryExpression =
                                new BinaryExpression
                                {
                                    Token = null,
                                    Warning = null,
                                    Strength = OPStrength.Comparison,
                                    StartIndex = 0,
                                    EndIndex = 8,
                                    Inner =
                                                                    new BinaryExpression
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Strength = OPStrength.Comparison,
                                                                        StartIndex = 0,
                                                                        EndIndex = 6,
                                                                        Inner =
                                                                                                            new BracketExpression
                                                                                                            {
                                                                                                                Token = null,
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.Add,
                                                                                                                StartIndex = 1,
                                                                                                                EndIndex = 5,
                                                                                                                Inner =
                                                                                                                                                        new BinaryExpression
                                                                                                                                                        {
                                                                                                                                                            Token = null,
                                                                                                                                                            Warning = null,
                                                                                                                                                            Strength = OPStrength.Multiple,
                                                                                                                                                            StartIndex = 1,
                                                                                                                                                            EndIndex = 3,
                                                                                                                                                            Inner =
                                                                                                                                                                                                        new BinaryExpression
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = null,
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Strength = OPStrength.Multiple,
                                                                                                                                                                                                            StartIndex = 1,
                                                                                                                                                                                                            EndIndex = 1,
                                                                                                                                                                                                            Inner =
                                                                                                                                                                                                                                                            new BinaryExpression
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                Token = new Token("5257.8475"),
                                                                                                                                                                                                                                                                Warning = null,
                                                                                                                                                                                                                                                                Strength = OPStrength.Multiple,
                                                                                                                                                                                                                                                                StartIndex = 1,
                                                                                                                                                                                                                                                                EndIndex = 1,
                                                                                                                                                                                                                                                                Inner = null,
                                                                                                                                                                                                                                                                Appendix = null
                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                            ,
                                                                                                                                                                                                            Appendix = null
                                                                                                                                                                                                        }
                                                                                                                                                                                                        ,
                                                                                                                                                            Appendix =
                                                                                                                                                                                                        new AppendixExpression(new OP("*", OPStrength.Multiple, 11), 3, -1)
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Inner =
                                                                                                                                                                                                                                                            new BinaryExpression
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                Token = new Token("-5"),
                                                                                                                                                                                                                                                                Warning = null,
                                                                                                                                                                                                                                                                Strength = OPStrength.Multiple,
                                                                                                                                                                                                                                                                StartIndex = 3,
                                                                                                                                                                                                                                                                EndIndex = 3,
                                                                                                                                                                                                                                                                Inner = null,
                                                                                                                                                                                                                                                                Appendix = null
                                                                                                                                                                                                                                                            }

                                                                                                                                                                                                        }

                                                                                                                                                        }
                                                                                                                                                        ,
                                                                                                                Appendix =
                                                                                                                                                        new AppendixExpression(new OP("+", OPStrength.Add, 14), 5, -1)
                                                                                                                                                        {
                                                                                                                                                            Inner =
                                                                                                                                                                                                        new BinaryExpression
                                                                                                                                                                                                        {
                                                                                                                                                                                                            Token = new Token("3"),
                                                                                                                                                                                                            Warning = null,
                                                                                                                                                                                                            Strength = OPStrength.Add,
                                                                                                                                                                                                            StartIndex = 5,
                                                                                                                                                                                                            EndIndex = 5,
                                                                                                                                                                                                            Inner = null,
                                                                                                                                                                                                            Appendix = null
                                                                                                                                                                                                        }

                                                                                                                                                        }

                                                                                                            }
                                                                                                            ,
                                                                        Appendix = null
                                                                    }
                                                                    ,
                                    Appendix =
                                                                    new AppendixExpression(new OP(">", OPStrength.Comparison, 18), 8, -1)
                                                                    {
                                                                        Inner =
                                                                                                            new BinaryExpression
                                                                                                            {
                                                                                                                Token = new Token("0"),
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.Comparison,
                                                                                                                StartIndex = 8,
                                                                                                                EndIndex = 8,
                                                                                                                Inner = null,
                                                                                                                Appendix = null
                                                                                                            }

                                                                    }

                                }


                            }
                        }
                    }
                }
            },
            {
                Tests.Expressions.Expression6, new ExpressionData
                {
                    Culture = new Dictionary<string, ExpressionData.CultureData>
                    {
                        {
                            "cs-CZ",
                            new ExpressionData.CultureData
                            {

                                PrettyPrint = "5 / 0",
                                PrettyPrintWithSeparators = "5 / 0",
                                ResultString = "1.7976931348623157E+308",
                                ResultStringWithSeparators = "1.7976931348623157E+308",
                                Tokens = new List<Token> {new Token("5"), new OP("/"), new Token("0")},
                                Warning = null,
                                Tree =
                                new ExpressionContextTree(new Token("placeholder"))
                                {
                                    Token = null,
                                    Warning = null,
                                    Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                    {

                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = new Token("5"),
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                        })
                                                                    },


                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = new OP("/"),
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                        })
                                                                    },


                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = new Token("0"),
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                        })
                                                                    },


                                    })
                                },

                                BinaryExpression =
                                new BinaryExpression
                                {
                                    Token = null,
                                    Warning = null,
                                    Strength = OPStrength.Multiple,
                                    StartIndex = 0,
                                    EndIndex = 2,
                                    Inner =
                                                                    new BinaryExpression
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Strength = OPStrength.Multiple,
                                                                        StartIndex = 0,
                                                                        EndIndex = 0,
                                                                        Inner =
                                                                                                            new BinaryExpression
                                                                                                            {
                                                                                                                Token = new Token("5"),
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.Multiple,
                                                                                                                StartIndex = 0,
                                                                                                                EndIndex = 0,
                                                                                                                Inner = null,
                                                                                                                Appendix = null
                                                                                                            }
                                                                                                            ,
                                                                        Appendix = null
                                                                    }
                                                                    ,
                                    Appendix =
                                                                    new AppendixExpression(new OP("/", OPStrength.Multiple, 2), 2, -1)
                                                                    {
                                                                        Inner =
                                                                                                            new BinaryExpression
                                                                                                            {
                                                                                                                Token = new Token("0"),
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.Multiple,
                                                                                                                StartIndex = 2,
                                                                                                                EndIndex = 2,
                                                                                                                Inner = null,
                                                                                                                Appendix = null
                                                                                                            }

                                                                    }

                                }


                            }
                        },
                        {
                            "en-US",
                            new ExpressionData.CultureData
                            {

                                PrettyPrint = "5 / 0",
                                PrettyPrintWithSeparators = "5 / 0",
                                ResultString = "1.7976931348623157E+308",
                                ResultStringWithSeparators = "1.7976931348623157E+308",
                                Tokens = new List<Token> {new Token("5"), new OP("/"), new Token("0")},
                                Warning = null,
                                Tree =
                                new ExpressionContextTree(new Token("placeholder"))
                                {
                                    Token = null,
                                    Warning = null,
                                    Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                    {

                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = new Token("5"),
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                        })
                                                                    },


                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = new OP("/"),
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                        })
                                                                    },


                                                                    new ExpressionContextTree(new Token("placeholder"))
                                                                    {
                                                                        Token = new Token("0"),
                                                                        Warning = null,
                                                                        Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                                                        {

                                                                        })
                                                                    },


                                    })
                                },

                                BinaryExpression =
                                new BinaryExpression
                                {
                                    Token = null,
                                    Warning = null,
                                    Strength = OPStrength.Multiple,
                                    StartIndex = 0,
                                    EndIndex = 2,
                                    Inner =
                                                                    new BinaryExpression
                                                                    {
                                                                        Token = null,
                                                                        Warning = null,
                                                                        Strength = OPStrength.Multiple,
                                                                        StartIndex = 0,
                                                                        EndIndex = 0,
                                                                        Inner =
                                                                                                            new BinaryExpression
                                                                                                            {
                                                                                                                Token = new Token("5"),
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.Multiple,
                                                                                                                StartIndex = 0,
                                                                                                                EndIndex = 0,
                                                                                                                Inner = null,
                                                                                                                Appendix = null
                                                                                                            }
                                                                                                            ,
                                                                        Appendix = null
                                                                    }
                                                                    ,
                                    Appendix =
                                                                    new AppendixExpression(new OP("/", OPStrength.Multiple, 2), 2, -1)
                                                                    {
                                                                        Inner =
                                                                                                            new BinaryExpression
                                                                                                            {
                                                                                                                Token = new Token("0"),
                                                                                                                Warning = null,
                                                                                                                Strength = OPStrength.Multiple,
                                                                                                                StartIndex = 2,
                                                                                                                EndIndex = 2,
                                                                                                                Inner = null,
                                                                                                                Appendix = null
                                                                                                            }

                                                                    }

                                }


                            }
                        }
                    }
                }
            },
            {
                Tests.Expressions.Expression7, new ExpressionData
                {
                    Culture = new Dictionary<string, ExpressionData.CultureData>
                    {
                        {
                            "cs-CZ",
                            new ExpressionData.CultureData
                            {

                                PrettyPrint = "5x -2",
                                PrettyPrintWithSeparators = "5x -2",
                                ResultString = "0",
                                ResultStringWithSeparators = "0",
                                Tokens = new List<Token> {},
                                Warning = Warning.CreateForTesting("exp007"),
                                Tree =
                                new ExpressionContextTree(new Token("placeholder"))
                                {
                                    Token = null,
                                    Warning = Warning.CreateForTesting("exp007"),
                                    Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                    {

                                    })
                                },

                                BinaryExpression =
                                new BinaryExpression
                                {
                                    Token = null,
                                    Warning = Warning.CreateForTesting("exp007"),
                                    Strength = OPStrength.LogicalOR,
                                    StartIndex = 0,
                                    EndIndex = 0,
                                    Inner = null,
                                    Appendix = null
                                }


                            }
                        },
                        {
                            "en-US",
                            new ExpressionData.CultureData
                            {

                                PrettyPrint = "5x -2",
                                PrettyPrintWithSeparators = "5x -2",
                                ResultString = "0",
                                ResultStringWithSeparators = "0",
                                Tokens = new List<Token> {},
                                Warning = Warning.CreateForTesting("exp007"),
                                Tree =
                                new ExpressionContextTree(new Token("placeholder"))
                                {
                                    Token = null,
                                    Warning = Warning.CreateForTesting("exp007"),
                                    Children = new LinkedList<ExpressionContextTree>(new List<ExpressionContextTree>
                                    {

                                    })
                                },

                                BinaryExpression =
                                new BinaryExpression
                                {
                                    Token = null,
                                    Warning = Warning.CreateForTesting("exp007"),
                                    Strength = OPStrength.LogicalOR,
                                    StartIndex = 0,
                                    EndIndex = 0,
                                    Inner = null,
                                    Appendix = null
                                }


                            }
                        }
                    }
                }
            },
        };
    }
}
