export default {
    tasks: state => state.tasks.filter((task)=>{return !task.complete}),
    CompleteTasks: state => state.tasks.filter((task)=>{return task.complete})
}


// export default{
//     ListTasks(state){
//         return state.tasks.filter((task)=>{return !task.complete})
//     }
//     ,
//     CompleteTasks(state){
//         return  state.tasks.filter((task)=>{return task.complete})
//     }
// }