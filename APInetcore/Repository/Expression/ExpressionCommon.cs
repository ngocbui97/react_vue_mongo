using Repository.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace Repository
{
    public class ExpressionCommon
    {
        public static Expression<Func<T, bool>> ConditionExpression<T>(ProEntity[] pros)
        {
            BinaryExpression filter = null;
            var param = Expression.Parameter(typeof(T));

            foreach (ProEntity pro in pros)
            {
                var columnExpress = Expression.PropertyOrField(param, pro.field_name);
                var valueExpress = Expression.Constant(pro.value);
                var conditionExpress = Expression.Equal(columnExpress, valueExpress);
                filter = (filter != null) ? Expression.And(filter, conditionExpress) : conditionExpress;
            }

            return Expression.Lambda<Func<T, bool>>(filter, param);
        }

        public static Expression<Func<T, T>> UpdateExpression<T>(ProEntity[] pros) where T : new()
        {
            T obj = new T();
            var param = Expression.Parameter(typeof(T));
            NewExpression newExpress = Expression.New(typeof(T));
            var properties = obj.GetType().GetProperties().Where(item => item.GetGetMethod().IsVirtual == false);

            List<MemberAssignment> memberBindings = new List<MemberAssignment>();
            foreach (var pro in pros)
            {
                var property = properties.FirstOrDefault(item => item.Name == pro.field_name);
                if (property != null)
                {
                    MemberAssignment member = Expression.Bind(property, Expression.Constant(pro.value, property.PropertyType));
                    memberBindings.Add(member);
                }
            }

            MemberInitExpression memberInit = Expression.MemberInit(newExpress, memberBindings);

            return Expression.Lambda<Func<T, T>>(memberInit, param);
        }
    }
}
