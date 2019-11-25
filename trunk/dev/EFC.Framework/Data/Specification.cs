using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EFC.Framework.Data
{
    public class Specification<T>
    {
        #region Fields

        /// <summary>
        /// The expression predicate.
        /// </summary>
        private readonly Expression<Func<T, bool>> expression;

        /// <summary>
        /// Function to evaluate the expression against an instance.
        /// </summary>
        private Func<T, bool> evaluateExpression;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Specification class.
        /// </summary>
        /// <param name="predicate">Expression predicate.</param>
        public Specification(Expression<Func<T, bool>> predicate)
        {
            this.expression = predicate;
        }

        /// <summary>
        /// Initializes a new instance of the Specification class.
        /// </summary>
        protected Specification()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the expression predicate.
        /// </summary>
        /// <value>The expression predicate.</value>
        public virtual Expression<Func<T, bool>> Predicate
        {
            get
            {
                if (expression != null)
                {
                    return expression;
                }

                throw new System.Data.InvalidExpressionException("Argument Predicate Not Overridden");
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Evaluates the specification against an instance.
        /// </summary>
        /// <param name="candidate">The instance against which the specificaton is to be evaluated.</param>
        /// <returns>Should return <c>true</c> if the specification was satisfied by the entity, else <c>false</c>.</returns>
        public bool IsSatisfiedBy(T candidate)
        {
            if (evaluateExpression == null)
            {
                evaluateExpression = expression.Compile();
            }

            return evaluateExpression(candidate);
        }

        #endregion
    }
}
