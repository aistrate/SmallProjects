﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserCombinators
{
    // Term and its derived classes define the AST for terms in the MiniML language.
    public abstract class Term
    {
    }

    public class LambdaTerm : Term
    {
        public LambdaTerm(string i, Term t)
        {
            Ident = i;
            Term = t;
        }
        
        public readonly string Ident;
        public readonly Term Term;

        public override string ToString()
        {
            //return string.Format("Lambda {{\"{0}\", LambdaBody={1}}}", Ident, Term);
            return string.Format("\\{0} -> {1}", Ident, Term);
        }
    }

    public class LetTerm : Term
    {
        public LetTerm(string i, Term r, Term b)
        {
            Ident = i;
            Rhs = r;
            Body = b;
        }
        
        public readonly string Ident;
        public readonly Term Rhs;
        public Term Body;

        public override string ToString()
        {
            //return string.Format("Let {{\"{0}\",\nRhs={1}, \n\nLetBody=\n{2}}}", Ident, Rhs, Body);
            return string.Format("let {0} = {1} in\n{2}", Ident, Rhs, Body);
        }
    }

    public class AppTerm : Term
    {
        public AppTerm(Term func, Term[] args)
        {
            Func = func;
            Args = args;
        }
        
        public readonly Term Func;
        public readonly Term[] Args;

        public override string ToString()
        {
            //return string.Format("Apply {{Func={0}, Args=[{1}]}}", Func, string.Join(", ", Args.Select(a => a.ToString()).ToArray()));
            return string.Format("({0} {1})", Func, string.Join(" ", Args.Select(a => a.ToString()).ToArray()));
        }
    }
    
    public class VarTerm : Term
    {
        public VarTerm(string ident)
        {
            Ident = ident;
        }
        
        public readonly string Ident;

        public override string ToString()
        {
            //return string.Format("Var{{\"{0}\"}}", Ident);
            return string.Format("{0}", Ident);
        }
    }
}
