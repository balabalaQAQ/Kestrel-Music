/**
 * 这段代码演示了使用 Fetch API 的常规方式
 * 关于 Fetch API，请参阅：https://developer.mozilla.org/zh-CN/docs/Web/API/Fetch_API/Using_Fetch
 * */

const uri = 'https://localhost:5001/api/MusicSingle';   // Web API 的访问服务地址
let todos = [];                // 待办事宜的数据集合 

/**
 * 使用 fetch 获取 Web API 提供的 TodoItem 对象集合数据.
 * */
function getItems() {
    fetch(uri)
        // 提取 uri 返回的数据,这个接口缺省使用无参数的 Get 方式
        .then(response => response.json())
        // 将返回的数据提交到初始化列表元素处理方法 _displayItems(data) 中
        .then(data => _displayItems(data))
        .catch(error => console.error('无法获取 TodoItem 对象集合数据。', error));
}

/**
 * 添加一个 TodoItem 对象
 * */
function addItem() {
    // 提取指定表单元素( id="add-name")的值
    const addNameTextbox = document.getElementById('add-name');
    const addPriceTextbox = document.getElementById('add-price');
    const addDescriptionTextbox = document.getElementById('add-description');
    /**
    var Sex = true;
   
    for (var i = 0; i < addSexTextbox.length; i++) {
        if (addSexTextbox.item(i).checked)
        {
            sex = addSexTextbox.item(i).getAttribute("value");
        }
    }
     * */
    console.log(addNameTextbox);
    // 创建待提交的数据对象
    const item = {
        Price: parseFloat(addPriceTextbox.value.trim()),
        Id: "4dc281ee-2081-4e07-be4d-89de00e60962",
        Name: addNameTextbox.value.trim(),
        Description: addDescriptionTextbox.value.trim(),
     

    };
    console.log(item)
    console.log(uri)
    // 使用 fetch 提交
    fetch(uri, {
        method: 'POST',      // Http 提交方式
        headers: {           // Http 头   
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)  // 提交的 Http body,即提交的具体数据内容
    })

        .then(response => response.json())  // 获取返回的响应,在这里不处理返回的响应,例如跳转至 新增数据的明细
        .then(() => {
            getItems();                      // 执行数据列表
            addNameTextbox.value = '';
            addPriceTextbox.value = '';
            addDescriptionTextbox.value = '';// 清空输入事项名称的表单项
        })
        .catch(error => console.error('无法添加数据。', error));
}

/**
 * 根据参数 id 删除对应 id 的 TodoItem 对象
 * @param {any} id 待删除对象的 id
 */
function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItems())  // 直接跳转到数据列表
        .catch(error => console.error('无法删除指定的数据。', error));
}

/**
 * 获取并显示需要编辑的 TodoItem 对象数据
 * @param {any} id 待编辑的数据的 id
 */
function displayEditForm(id) {
    const item = todos.find(item => item.id === id);

    document.getElementById('edit-name').value = item.name;
    document.getElementById('edit-id').value = item.id;
    document.getElementById('edit-isComplete').checked = item.isComplete;
    document.getElementById('editForm').style.display = 'block';
}

/**
 * 提交更新的 TodoItem 对象数据
 * @returns {bool} 返回状态
 * */
function updateItem() {
    const itemId = document.getElementById('edit-id').value;
    const item = {
        id: itemId,
        isComplete: document.getElementById('edit-isComplete').checked,
        name: document.getElementById('edit-name').value.trim()
    };

    fetch(`${uri}/${itemId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(() => getItems())
        .catch(error => console.error('无法更新指定的数据。', error));

    closeInput();
    return false;
}


/**
 * 关闭编辑输入区
 * */
function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

/**
 * 显示数据集合数量
 * @param {any} itemCount 数据集合数量
 */
function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'to-do' : 'to-dos';
    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

/**
 * 根据传入的数据集合,显示数据列表
 * @param {any} data 待显示的数据集合
 */
function _displayItems(data) {
    // 提取元素表体元素
    const tBody = document.getElementById('todos');
    tBody.innerHTML = '';
    // 显示数量
    _displayCount(data.length);
    // 创建一个简单的 button 对象,供后续代码克隆,如果需要定义统一的样式的时候,这个方式特别有用.
    const button = document.createElement('button');
    // 根据传入的数据遍历创建列表行
    data.forEach(item => {
        // 创建一个 input type='checkbox' 的控件,并设置相应的属性,用于显示待办事先的状态
        let isCompleteCheckbox = document.createElement('input');
        isCompleteCheckbox.type = 'checkbox';
        isCompleteCheckbox.disabled = true;
        isCompleteCheckbox.checked = item.isComplete;
        // 创建"编辑"按钮,绑定相关的单击事件,事件执行方法:displayEditForm('${item.id}')
        let editButton = button.cloneNode(false);
        editButton.innerText = '编辑';
        editButton.setAttribute('onclick', `displayEditForm('${item.id}')`);
        // 创建"删除"按钮,绑定相关的单击事件,事件执行方法:deleteItem('${item.id}')
        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = '删除';
        deleteButton.setAttribute('onclick', `deleteItem('${item.id}')`);
        // 创建一个<tr></tr>,并插入到 <tbody id="todos"></tbody> 中
        let tr = tBody.insertRow();
        // 创建一个<td></td>中,并设置为<tr></tr>的第 0 列,将之前定义的 isCompleteCheckbox 作为内容子元素加入其中
        let td1 = tr.insertCell(0);
        td1.appendChild(isCompleteCheckbox);
        // 创建一个<td></td>中,并设置为<tr></tr>的第 1 列,将遍历元素对象的 name 属性作为内容子元素加入其中
        let td2 = tr.insertCell(1);
        let textNode = document.createTextNode(item.name);
        td2.appendChild(textNode);
        // 创建一个<td></td>中,并设置为<tr></tr>的第 2 列,将之前定义的 editButton 作为内容子元素加入其中
        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);
        // 创建一个<td></td>中,并设置为<tr></tr>的第 3 列,将之前定义的 deleteButton 作为内容子元素加入其中
        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });
    // 将更新后的 data 直接赋值给 <tbody id="todos"></tbody>
    todos = data;
}