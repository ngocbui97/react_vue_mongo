export default{
    addTask(state,value){
        var task ={
            isEditing: false,
            content: value,
            complete:false,
            id:state.tasks.length+1
        }
        state.tasks.push(task);
    },
    editTask(state,task){
        var data = JSON.parse(JSON.stringify(state.tasks));
        data.map(item => {
            if(item.id===task.id){
                item.content =task.content;
                item.isEditing = false;
                item.complete =true;
            }
        });
        state.tasks = data;
        console.log("end2"+ JSON.stringify(state.tasks));
    },
    beginEdit(state,id){
        console.log(typeof(state.tasks)+state.tasks);
        console.log("start"+ JSON.stringify(state.tasks));
        var data = JSON.parse(JSON.stringify(state.tasks));
        data.forEach(item=>{
            if(item.id===id){
                item.isEditing = true;
                console.log("find item:"+item);
            }
        })
        state.tasks = data;
        console.log("end"+ JSON.stringify(state.tasks));
    },
    deleteTask(state,id){
        var data = JSON.parse(JSON.stringify(state.tasks));
        data = data.filter (item=>{
            return item.id !=id;
        })
        state.tasks = data;
    }
}